﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallLogger
    {
        private readonly string _path;
        private Task _logTask;
        private readonly ConcurrentQueue<JObject> _logQueue;
        private readonly JArray _logArray;
        private readonly Mutex ballsMutex = new Mutex();
        private Mutex fileMutex = new Mutex();

        public BallLogger()
        {
            string tempPath = Path.GetTempPath();
            _path = tempPath + "BallsLog.json";
            _logQueue = new ConcurrentQueue<JObject>();
            if (File.Exists(_path))
            {
                try
                {
                    string input = File.ReadAllText(_path);
                    _logArray = JArray.Parse(input);
                    return;
                }
                catch (JsonReaderException)
                {
                    _logArray = new JArray();
                }
            }

            _logArray = new JArray();
            File.Create(_path);
        }


        public void EnqueueToLoggingQueue(IBall ball)
        {
            ballsMutex.WaitOne();
            try
            {
                JObject timeObject = JObject.FromObject(ball);
                timeObject["Time"] = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff");

                _logQueue.Enqueue(timeObject);

                if (_logTask == null || _logTask.IsCompleted)
                {
                    _logTask = Task.Factory.StartNew(WriteLogToFile);
                }
            }
            finally
            {
                ballsMutex.ReleaseMutex();
            }
        }


        private async void WriteLogToFile()
        {
            while (_logQueue.TryDequeue(out JObject ball))
            {
                _logArray.Add(ball);
            }
            string output = JsonConvert.SerializeObject(_logArray);
            fileMutex.WaitOne();
            try
            {
                File.WriteAllText(_path, output);
            }
            finally
            {
                fileMutex.ReleaseMutex();
            }

        }
    }



}

