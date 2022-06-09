using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallLogger : BallLoggerApi
    {
        private readonly string path;
        private Task logTask;
        private readonly ConcurrentQueue<JObject> queue;
        private readonly JArray logArray;
        private readonly Mutex ballsMutex = new Mutex();
        private Mutex fileMutex = new Mutex();

        public BallLogger()
        {
            path = Path.GetTempPath() + "PWBallLog.json";
            queue = new ConcurrentQueue<JObject>();
            if (File.Exists(path))
            {
                try
                {
                    string input = File.ReadAllText(path);
                    logArray = JArray.Parse(input);
                    return;
                }
                catch (JsonReaderException)
                {
                    logArray = new JArray();
                }
            }

            logArray = new JArray();
            File.Create(path);
        }


        public override void EnqueueToLoggingQueue(IBall ball)
        {
            ballsMutex.WaitOne();
            try
            {
                JObject timeObject = JObject.FromObject(ball);
                timeObject["Time"] = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff");

                queue.Enqueue(timeObject);

                if (logTask == null || logTask.IsCompleted)
                {
                    logTask = Task.Factory.StartNew(WriteLogToFile);
                }
            }
            finally
            {
                ballsMutex.ReleaseMutex();
            }
        }


        private async void WriteLogToFile()
        {
            while (queue.TryDequeue(out JObject ball))
            {
                logArray.Add(ball);
            }
            fileMutex.WaitOne();
            try
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(logArray));
            }
            finally
            {
                fileMutex.ReleaseMutex();
            }

        }
    }



}

