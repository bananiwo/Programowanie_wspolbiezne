﻿using Data;
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
            dataLayer = DataAbstractApi.CreateApi(width, height);
            Width = width;
            Height = height;

        }

        public override int Width { get; set; }
        public override int Height { get; set; }

        public override void Start()
        {
            for (int i = 0; i < dataLayer.GetCount; i++)
            {
                dataLayer.GetBall(i).CreateMovementTask(50);
            }
        }

        public override void Stop()
        {
            for (int i = 0; i < dataLayer.GetCount; i++)
            {
                dataLayer.GetBall(i).Stop();

            }
        }


        public override void WallCollision(IBall ball)
        {

            double diameter = ball.Radius;

            double right = Width - diameter;

            double down = Height - diameter;


            if (ball.X <= error)
            {
                if (ball.NewX <= 0)
                {
                    ball.NewX = -ball.NewX;
                }
            }

            else if (ball.X >= right - error)
            {
                if (ball.NewX > 0)
                {
                    ball.NewX = -ball.NewX;
                }
            }
            if (ball.Y <= error)
            {
                if (ball.NewY <= 0)
                {
                    ball.NewY = -ball.NewY;
                }
            }

            else if (ball.Y >= down - error)
            {
                if (ball.NewY > 0)
                {
                    ball.NewY = -ball.NewY;
                }
            }
        }

        public override void BallBounce(IBall ball)
        {
            for (int i = 0; i < dataLayer.GetCount; i++)
            {
                IBall secondBall = dataLayer.GetBall(i);
                if (ball.ID == secondBall.ID)
                {
                    continue;
                }

                if (Collision(ball, secondBall))
                {

                    double m1 = ball.Radius;
                    double m2 = secondBall.Radius;
                    double v1x = ball.NewX;
                    double v1y = ball.NewY;
                    double v2x = secondBall.NewX;
                    double v2y = secondBall.NewY;



                    double u1x = (m1 - m2) * v1x / (m1 + m2) + (2 * m2) * v2x / (m1 + m2);
                    double u1y = (m1 - m2) * v1y / (m1 + m2) + (2 * m2) * v2y / (m1 + m2);

                    double u2x = 2 * m1 * v1x / (m1 + m2) + (m2 - m1) * v2x / (m1 + m2);
                    double u2y = 2 * m1 * v1y / (m1 + m2) + (m2 - m1) * v2y / (m1 + m2);

                    ball.NewX = u1x;
                    ball.NewY = u1y;
                    secondBall.NewX = u2x;
                    secondBall.NewY = u2y;
                    return;

                }
            }
        }




        internal bool Collision(IBall a, IBall b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            return Distance(a, b) <= (a.Radius / 2 + b.Radius / 2);
        }

        internal double Distance(IBall a, IBall b)
        {
            double x1 = a.X + a.Radius / 2 + a.NewX;
            double y1 = a.Y + a.Radius / 2 + a.NewY;
            double x2 = b.X + b.Radius / 2 + b.NewY;
            double y2 = b.Y + b.Radius / 2 + b.NewY;

            return Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        }


        public override IList CreateBalls(int count)
        {
            int previousCount = dataLayer.GetCount;
            IList temp = dataLayer.CreateBallsList(count);
            for (int i = 0; i < dataLayer.GetCount - previousCount; i++)
            {
                dataLayer.GetBall(previousCount + i).PropertyChanged += BallPositionChanged;
            }
            return temp;
        }

        public override void ClearBalls()
        {
            dataLayer.ClearBalls();
        }

        public override IBall GetBall(int index)
        {
            return dataLayer.GetBall(index);
        }


        public override int GetCount { get => dataLayer.GetCount; }

        public override void BallPositionChanged(object sender, PropertyChangedEventArgs args)
        {
            IBall ball = (IBall)sender;
            mutex.WaitOne();
            ballLogger.EnqueueToLoggingQueue(ball);
            WallCollision(ball);
            BallBounce(ball);
            mutex.ReleaseMutex();
        }


    }
}