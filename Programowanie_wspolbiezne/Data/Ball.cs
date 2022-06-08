using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Ball : IBall
    {
        private readonly int radius;
        private readonly int id;
        private double x;
        private double y;
        private Vector2 velocity;
        private readonly Stopwatch stopwatch;
        private Task task;
        private bool stop = false;

        public Ball(int identyfikator, int size, double x, double y, Vector2 velocity)
        {
            id = identyfikator;
            this.radius = size;
            this.x = x;
            this.y = y;
            this.velocity = velocity;
            stopwatch = new Stopwatch();
        }

        public int ID { get => id; }
        public int Radius { get => radius; }

        public Vector2 Velocity { get => velocity; set
            {
                velocity = value;
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
            X += Velocity.X * time;
            Y += Velocity.Y * time;
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
            info.AddValue("Velocity", Velocity);
        }
    }
}
