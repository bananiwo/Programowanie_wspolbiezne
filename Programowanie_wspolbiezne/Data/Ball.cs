using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Data

{
    public interface IBall : INotifyPropertyChanged, ISerializable
    { 
        int ID { get; }
        int Radius { get; }
        double X { get; }
        double Y { get; }
        double NewX { get; set; }
        double NewY { get; set; }

        void Move(double time);
        void CreateMovementTask(int interval);

        void Stop();




    }

    internal class Ball : IBall
    {
        private readonly int radius;
        private readonly int id;
        private double x;
        private double y;
        private double newX;
        private double newY;
        private readonly Stopwatch stopwatch;
        private Task task;
        private bool stop = false;

        public Ball(int identyfikator, int size, double x, double y, double newX, double newY)
        {
            id = identyfikator;
            this.radius = size;
            this.x = x;
            this.y = y;
            this.newX = newX;
            this.newY = newY;
            stopwatch = new Stopwatch();
        }

        public int ID { get => id; }
        public int Radius { get => radius; }
        public double NewX
        {
            get => newX;
            set
            {
                if (value.Equals(newX))
                {
                    return;
                }

                newX = value;

            }
        }
        public double NewY
        {
            get => newY;
            set
            {
                if (value.Equals(newY))
                {
                    return;
                }

                newY = value;

            }
        }
        public double X
        {
            get => x;
            private set
            {
                if (value.Equals(x))
                {
                    return;
                }

                x = value;
                RaisePropertyChanged();
            }
        }
        public double Y
        {
            get => y;
            private set
            {
                if (value.Equals(y))
                {
                    return;
                }

                y = value;
                RaisePropertyChanged();
            }
        }

        public void Move(double time)
        {
            X += NewX * time;
            Y += NewY * time;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        internal void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void CreateMovementTask(int interval)
        {
            stop = false;
            task = Run(interval);
        }

        private async Task Run(int interval)
        {
            while (!stop)
            {
                stopwatch.Reset();
                stopwatch.Start();
                if (!stop)
                {
                    Move((interval - stopwatch.ElapsedMilliseconds) / 16);

                }
                stopwatch.Stop();

                int delay = (int)(interval - stopwatch.ElapsedMilliseconds);
                if (delay < 0)
                {
                    delay = 0;
                }
                await Task.Delay((int)delay);
            }
        }
        public void Stop()
        {
            stop = true;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", id);
            info.AddValue("Radius", radius);
            info.AddValue("X Position", X);
            info.AddValue("Y Position", Y);
            info.AddValue("X Velocity", NewX);
            info.AddValue("Y Velocity", NewY);
        }
    }
}

