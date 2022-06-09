using Data;
using System;
using System.Collections;
using System.Collections.Generic;
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
        private readonly BallLogger ballLogger = new BallLogger();
        private readonly int error = 10;


        public LogicApi(int width, int height)
        {
            dataLayer = DataAbstractApi.CreateDataApi(width, height);
            Width = width;
            Height = height;

        }

        public override int Width { get; set; }
        public override int Height { get; set; }

        public override void StartSimulating()
        {
            for (int i = 0; i < dataLayer.GetBallCounter; i++)
            {
                dataLayer.GetBallAt(i).CreateMovementTask(50);
            }
        }

        public override void StopSimulating()
        {
            for (int i = 0; i < dataLayer.GetBallCounter; i++)
            {
                dataLayer.GetBallAt(i).StopMovement();

            }
        }


        public override bool WallBounce(IBall ball)
        {

            double diameter = ball.Radius;
            double right = Width - diameter;
            double down = Height - diameter;
            bool isBounce = false;

            if (ball.X <= error)
            {
                if (ball.Velocity.X <= 0)
                {
                    ball.Velocity = new System.Numerics.Vector2(- ball.Velocity.X, ball.Velocity.Y);
                    isBounce = true;
                }
            }

            else if (ball.X >= right - error)
            {
                if (ball.Velocity.X > 0)
                {
                    ball.Velocity = new System.Numerics.Vector2(-ball.Velocity.X, ball.Velocity.Y);
                    isBounce = true;
                }
            }
            if (ball.Y <= error)
            {
                if (ball.Velocity.Y <= 0)
                {
                    ball.Velocity = new System.Numerics.Vector2(ball.Velocity.X, -ball.Velocity.Y);
                    isBounce = true;
                }
            }

            else if (ball.Y >= down - error)
            {
                if (ball.Velocity.Y > 0)
                {
                    ball.Velocity = new System.Numerics.Vector2(ball.Velocity.X, -ball.Velocity.Y);
                    isBounce = true;
                }
            }
            return isBounce;
        }

        public override bool BallBounce(IBall ball)
        {
            for (int i = 0; i < dataLayer.GetBallCounter; i++)
            {
                IBall secondBall = dataLayer.GetBallAt(i);
                if (ball.ID == secondBall.ID)
                {
                    continue;
                }

                if (DetectCollision(ball, secondBall))
                {
                    double m1 = ball.Radius;
                    double m2 = secondBall.Radius;
                    double v1x = ball.Velocity.X;
                    double v1y = ball.Velocity.Y;
                    double v2x = secondBall.Velocity.X;
                    double v2y = secondBall.Velocity.Y;


                    double u1x = (m1 - m2) * v1x / (m1 + m2) + (2 * m2) * v2x / (m1 + m2);
                    double u1y = (m1 - m2) * v1y / (m1 + m2) + (2 * m2) * v2y / (m1 + m2);

                    double u2x = 2 * m1 * v1x / (m1 + m2) + (m2 - m1) * v2x / (m1 + m2);
                    double u2y = 2 * m1 * v1y / (m1 + m2) + (m2 - m1) * v2y / (m1 + m2);

                    ball.Velocity = new System.Numerics.Vector2((float)u1x, (float)u1y);
                    secondBall.Velocity = new System.Numerics.Vector2((float)u2x, (float)u2y);
                    return true;

                }
            }
            return false;
        }


        internal bool DetectCollision(IBall ballI, IBall ballII)
        {
            if (ballI == null || ballII == null)
            {
                return false;
            }

            return EuclideanDistance(ballI, ballII) <= (ballI.Radius / 2 + ballII.Radius / 2);
        }

        internal double EuclideanDistance(IBall a, IBall b)
        {
            return Math.Sqrt((Math.Pow(a.X + a.Radius / 2 + a.Velocity.X - b.X + b.Radius / 2 + b.Velocity.X, 2) 
                + Math.Pow(a.Y + a.Radius / 2 + a.Velocity.Y - b.Y + b.Radius / 2 + b.Velocity.Y, 2)));
        }


        public override IList CreateBalls(int count)
        {
            int previousCount = dataLayer.GetBallCounter;
            IList temp = dataLayer.CreateBallsList(count);
            for (int i = 0; i < dataLayer.GetBallCounter - previousCount; i++)
            {
                dataLayer.GetBallAt(previousCount + i).PropertyChanged += BallPositionChanged;
            }
            return temp;
        }

        public override void ClearBalls()
        {
            dataLayer.ClearBalls();
        }

        public override IBall GetBallAt(int index)
        {
            return dataLayer.GetBallAt(index);
        }


        public override int GetBallCounter { get => dataLayer.GetBallCounter; }

        public override void BallPositionChanged(object sender, PropertyChangedEventArgs args)
        {
            IBall ball = (IBall)sender;
            mutex.WaitOne();

            if (WallBounce(ball) || BallBounce(ball))
            {
                ballLogger.EnqueueToLoggingQueue(ball);
            }
            mutex.ReleaseMutex();
        }


    }
}
