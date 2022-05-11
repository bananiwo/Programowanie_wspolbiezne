using Data;
using System.Diagnostics;
using System.Numerics;

namespace Logic
{
    internal class LogicBall : LogicBallApi
    {
        BallApi _ball;
        public LogicBall(BallApi ball)
        {
            Debug.WriteLine("LogicBall created");

            Ball = ball;
            _ball.PositionChanged += bl_PositionChanged;
        }
        public static void bl_PositionChanged(object sender, Vector2 pos)
        {
            Console.WriteLine("BallLogic pos: " + pos);
            Debug.WriteLine("BallLogic pos: " + pos);
        }

        private void BounceIfContactsWall()
        {
            float posX = _ball.GetPosition().X;
            float posY = _ball.GetPosition().Y;
            float dirX = _ball.GetDirection().X;
            float dirY = _ball.GetDirection().Y;
            double r = _ball.GetRadius();

            if (posX < 0 + r && dirX <= 0)
                _ball.SetDirection(new Vector2(-dirX, dirY));
            else if (posX >= _ball.GetBoard().X && dirX >= 0)
                _ball.SetDirection(new Vector2(-dirX, dirY));
            else if (posY < 0 + r && dirY <= 0)
                _ball.SetDirection(new Vector2(dirX, -dirY));
            else if (posY >= _ball.GetBoard().Y && dirY >= 0)
                _ball.SetDirection(new Vector2(dirX, -dirY));
        }

        public BallApi Ball { get => _ball; set => _ball = value; }

        public override Vector2 Position
        {
            get
            {
                Vector2 currentPos = Ball.GetPosition();
                OnPositionChangedLogic(currentPos);
                return currentPos;
            }
        }
        public override double Radius { get => Ball.GetRadius(); }


    }
}
