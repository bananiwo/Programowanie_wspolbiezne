using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class Collisions
    {
        internal static void WallBounce(IBall ball, int width, int height, int error)
        {

            double diameter = ball.Radius;
            double right = width - diameter;
            double down = height - diameter;

            if (ball.X <= error)
            {
                if (ball.Velocity.X <= 0)
                {
                    ball.Velocity = new System.Numerics.Vector2(-ball.Velocity.X, ball.Velocity.Y);
                }
            }

            else if (ball.X >= right - error)
            {
                if (ball.Velocity.X > 0)
                {
                    ball.Velocity = new System.Numerics.Vector2(-ball.Velocity.X, ball.Velocity.Y);
                }
            }
            if (ball.Y <= error)
            {
                if (ball.Velocity.Y <= 0)
                {
                    ball.Velocity = new System.Numerics.Vector2(ball.Velocity.X, -ball.Velocity.Y);
                }
            }

            else if (ball.Y >= down - error)
            {
                if (ball.Velocity.Y > 0)
                {
                    ball.Velocity = new System.Numerics.Vector2(ball.Velocity.X, -ball.Velocity.Y);
                }
            }
        }

        internal static void BallBounce(IBall ball, ObservableCollection<IBall> balls)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                IBall secondBall = balls[i];
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
                    return;

                }
            }
        }


        internal static bool DetectCollision(IBall ballI, IBall ballII)
        {
            if (ballI == null || ballII == null)
            {
                return false;
            }

            return EuclideanDistance(ballI, ballII) <= (ballI.Radius / 2 + ballII.Radius / 2);
        }

        internal static double EuclideanDistance(IBall a, IBall b)
        {
            return Math.Sqrt((Math.Pow(a.X + a.Radius / 2 + a.Velocity.X - b.X + b.Radius / 2 + b.Velocity.X, 2)
                + Math.Pow(a.Y + a.Radius / 2 + a.Velocity.Y - b.Y + b.Radius / 2 + b.Velocity.Y, 2)));
        }
    }
}
