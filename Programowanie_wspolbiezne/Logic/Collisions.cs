using Data;
using System.Numerics;

namespace Logic
{
    public class Collisions
    {
        public void WallCollision(BallApi ballApi, Vector2 boardSize)
        {
            double diameter = 2 * BallCollectionApi.GetRadius(ballApi);
            float left = boardSize.X - (float)diameter;
            float bottom = boardSize.Y - (float)diameter;

            if (ballApi.Position.X < 0)
            {
                ballApi.Position = new Vector2(-ballApi.Position.X, ballApi.Position.Y);
                ballApi.Velocity = new Vector2(-ballApi.Velocity.X, ballApi.Velocity.Y);

            }
            else if (ballApi.Position.X > left)
            {
                ballApi.Position = new Vector2(left - (ballApi.Position.X - left), ballApi.Position.Y);
                ballApi.Velocity = new Vector2(-ballApi.Velocity.X, ballApi.Velocity.Y);
            }

            if (ballApi.Position.Y < 0)
            {
                ballApi.Position = new Vector2(ballApi.Position.X, -ballApi.Position.Y);
                ballApi.Velocity = new Vector2(ballApi.Velocity.X, -ballApi.Velocity.Y);

            }
            else if (ballApi.Position.Y > bottom)
            {
                ballApi.Position = new Vector2(ballApi.Position.X, bottom - (ballApi.Position.Y - bottom));
                ballApi.Velocity = new Vector2(ballApi.Velocity.X, -ballApi.Velocity.Y);
            }
        }

        public bool DetectCollision(BallApi first, BallApi second)
        {
            if (first == null || second == null)
            {
                return false;
            }
            double distance = Vector2.Distance(first.Position, second.Position);
            if (distance <= second.Radius + first.Radius)
            {
                return true;
            }
            return false;

        }



        public void BallCollision(List<BallApi> ballApis, BallApi ballApi)
        {
            foreach (var otherBall in ballApis)
            {
                if (otherBall != ballApi)
                {
                    if (DetectCollision(ballApi, otherBall))
                    {
                        ballApi.Step(-1);
                        double radiusBallApi = ballApi.Radius;
                        double radiusOtherBall = otherBall.Radius;
                        double xVelocityBallApi = ballApi.Velocity.X;
                        double yVelocityBallApi = ballApi.Velocity.Y;
                        double xVelocityOtherBall = otherBall.Velocity.X;
                        double yVelocityOtherBall = otherBall.Velocity.Y;

                        double xVelocityBallApiAfterCollision = (radiusBallApi - radiusOtherBall) * xVelocityBallApi / (radiusBallApi + radiusOtherBall) + (2 * radiusOtherBall) * xVelocityOtherBall / (radiusBallApi + radiusOtherBall);
                        double yVelocityBallApiAfterCollision = (radiusBallApi - radiusOtherBall) * yVelocityBallApi / (radiusBallApi + radiusOtherBall) + (2 * radiusOtherBall) * yVelocityOtherBall / (radiusBallApi + radiusOtherBall);

                        ballApi.Velocity = new Vector2((float)xVelocityBallApiAfterCollision, (float)yVelocityBallApiAfterCollision);

                        double xVelocityOtherBallAfterCollision = 2 * radiusBallApi * xVelocityBallApi / (radiusBallApi + radiusOtherBall) + (radiusOtherBall - radiusBallApi) * xVelocityOtherBall / (radiusBallApi + radiusOtherBall);
                        double yVelocityOtherBallAfterCollision = 2 * radiusBallApi * yVelocityBallApi / (radiusBallApi + radiusOtherBall) + (radiusOtherBall - radiusBallApi) * yVelocityOtherBall / (radiusBallApi + radiusOtherBall);

                        otherBall.Velocity = new Vector2((float)xVelocityOtherBallAfterCollision, (float)yVelocityOtherBallAfterCollision);
                    }
                }
            }
        }
    }
}
