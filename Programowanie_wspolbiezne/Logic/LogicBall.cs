using Data;
using System.Diagnostics;
using System.Numerics;

namespace Logic
{
    internal class LogicBall : LogicBallApi
    {
        static BallApi _ball;
        static LogicBall _logicBall;
        private Vector2 _position;
        Vector2 _logicPosition;
        public LogicBall(BallApi ball)
        {
            Ball = ball;
            _logicBall = this;
            Position = Ball.GetPosition();
            Ball.PositionChangeOnData += logic_PositionChangeOnData;
            Debug.WriteLine("LOgicBall");
            Debug.WriteLine(Position);

        }


        public BallApi Ball { get => _ball; set => _ball = value; }


        public override double Radius { get => Ball.GetRadius(); }
        public override Vector2 Position { get => _position; set => _position = value; }

        public static void logic_PositionChangeOnData(object sender, Vector2 newPos)
        {
            _logicBall.OnPositionChangeOnLogic(newPos);

        }


    }
}
