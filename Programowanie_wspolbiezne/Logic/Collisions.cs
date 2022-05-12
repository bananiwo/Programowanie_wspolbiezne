using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class Collisions
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



        public void BallCollision(List<BallApi> ballApis, BallApi ballApi)
        {
            foreach (var ball in ballApis)
            {
                double distance = Vector2.Distance(ballApi.Position, ball.Position);
                if (distance <= ball.Radius + ballApi.Radius)
                {
                    var radiusBallApi = ballApi.Radius;
                    var radiusBall = ball.Radius;
                    var xVelocityBallApi = ballApi.Velocity.X;
                    var yVelocityBallApi = ballApi.Velocity.Y;
                    var xVelocityBall = ball.Velocity.X;
                    var yVelocityBall = ball.Velocity.Y;

                    var xVelocityBallApiAfterCollision = (radiusBallApi - radiusBall) * xVelocityBallApi / (radiusBallApi + radiusBall) + (2 * radiusBall) * xVelocityBall / (radiusBallApi + radiusBall);
                    var yVelocityBallApiAfterCollision = (radiusBallApi - radiusBall) * yVelocityBallApi / (radiusBallApi + radiusBall) + (2 * radiusBall) * yVelocityBall / (radiusBallApi + radiusBall);

                    ballApi.Position = new Vector2((float)xVelocityBallApiAfterCollision, (float)yVelocityBallApiAfterCollision);

                    var xVelocityBallAfterCollision = 2 * radiusBallApi * xVelocityBallApi / (radiusBallApi + radiusBall) + (radiusBall - radiusBallApi) * xVelocityBall / (radiusBallApi + radiusBall);
                    var yVelocityBallAfterCollision = 2 * radiusBallApi * yVelocityBallApi / (radiusBallApi + radiusBall) + (radiusBall - radiusBallApi) * yVelocityBall / (radiusBallApi + radiusBall);

                    ball.Position = new Vector2((float)xVelocityBallAfterCollision, (float)yVelocityBallAfterCollision);


                }
            }
        }
    }
}
