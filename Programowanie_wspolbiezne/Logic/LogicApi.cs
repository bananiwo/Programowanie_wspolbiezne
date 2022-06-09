using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class LogicApi : LogicAbstractApi
    {
        private readonly DataAbstractApi dataLayer;
        private readonly Mutex mutex = new Mutex();
        private readonly Mutex mutexBall = new Mutex();
        private readonly Random random = new Random();
        private readonly int error = 0;

        private ObservableCollection<IBall> balls;

        public LogicApi(int width, int height)
        {
            dataLayer = DataAbstractApi.CreateDataApi(width, height);
            balls = new ObservableCollection<IBall>();
            Width = width;
            Height = height;

        }

        public override int Width { get; set; }
        public override int Height { get; set; }

        public ObservableCollection<IBall> Balls => balls;
        public override void ClearBalls() => balls.Clear();
        private int GetBallCounter { get => balls.Count; }
        private IBall GetBallAt(int index) => balls[index];


        public override void StartSimulating()
        {
            for (int i = 0; i < GetBallCounter; i++)
            {
                GetBallAt(i).CreateMovementTask(30);
            }
        }


        public override void StopSimulating()
        {
            for (int i = 0; i < GetBallCounter; i++)
            {
                GetBallAt(i).StopMovement();
            }
        }


        private IList CreateBallList(int count)
        {

            if (count > 0)
            {
                int ballsCount = balls.Count;
                for (int i = 0; i < count; i++)
                {
                    mutexBall.WaitOne();
                    int radius = 20;
                    IBall ball = DataAbstractApi.CreateBall(i + 1 + ballsCount,
                        radius,
                        random.Next(radius, Width - radius),
                        random.Next(radius, Height - radius),
                        new System.Numerics.Vector2((float)(random.Next(-10, 10) + random.NextDouble()), (float)(random.Next(-10, 10) + random.NextDouble())));

                    balls.Add(ball);
                    mutexBall.ReleaseMutex();

                }
            }
            if (count < 0)
            {
                for (int i = count; i < 0; i++)
                {

                    if (balls.Count > 0)
                    {
                        mutexBall.WaitOne();
                        balls.Remove(balls[balls.Count - 1]);
                        mutexBall.ReleaseMutex();
                    };

                }
            }
            return balls;
        }


        public override IList CreateBalls(int count)
        {
            int previousCount = GetBallCounter;
            IList temp = CreateBallList(count);
            for (int i = 0; i < GetBallCounter - previousCount; i++)
            {
                GetBallAt(previousCount + i).PropertyChanged += BallPositionChanged;
            }
            return temp;
        }


        public override void BallPositionChanged(object sender, PropertyChangedEventArgs args)
        {
            IBall ball = (IBall)sender;
            mutex.WaitOne();
            Collisions.WallBounce(ball, Width, Height, error);
            Collisions.BallBounce(ball, Balls);
            mutex.ReleaseMutex();
        }


    }
}
