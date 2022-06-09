using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading;

namespace Data
{
    internal class DataApi : DataAbstractApi
    {
        private ObservableCollection<IBall> balls { get; }
        private readonly Mutex mutex = new Mutex();
        private readonly Random random = new Random();
        private readonly BallLogger ballLogger = new BallLogger();

        public override int Width { get; }
        public override int Height { get; }



        public DataApi(int width, int height)
        {
            balls = new ObservableCollection<IBall>();
            Width = width;
            Height = height;

        }

        public override ObservableCollection<IBall> Balls => balls;

        public override void ClearBalls()
        {
            balls.Clear();
        }

        public override IList CreateBallsList(int count)
        {

            if (count > 0)
            {
                int ballsCount = balls.Count;
                for (int i = 0; i < count; i++)
                {
                    mutex.WaitOne();
                    int radius = 20;
                    IBall ball = new Ball(i + 1 + ballsCount, 
                        radius,
                        random.Next(radius, Width - radius),
                        random.Next(radius, Height - radius), 
                        new System.Numerics.Vector2((float)(random.Next(-10, 10) + random.NextDouble()),(float)(random.Next(-10, 10) + random.NextDouble())), ballLogger);

                    balls.Add(ball);
                    mutex.ReleaseMutex();

                }
            }
            if (count < 0)
            {
                for (int i = count; i < 0; i++)
                {

                    if (balls.Count > 0)
                    {
                        mutex.WaitOne();
                        balls.Remove(balls[balls.Count - 1]);
                        mutex.ReleaseMutex();
                    };

                }
            }
            return balls;
        }

        public override int GetBallCounter { get => balls.Count; }



        public override IBall GetBallAt(int index)
        {
            return balls[index];
        }


    }
}
