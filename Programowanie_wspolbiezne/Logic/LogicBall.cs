using Data;
using System.Diagnostics;
using System.Numerics;

namespace Logic
{
    internal class LogicBall : LogicBallApi
    {
        static BallApi _ball;
        static LogicBall _logicBall;
        Vector2 _logicPosition;
        public LogicBall(BallApi ball)
        {
            Ball = ball;
            _logicBall = this;
            Ball.PositionChangeOnData += logic_PositionChangeOnData;

        }


        public BallApi Ball { get => _ball; set => _ball = value; }

        public override Vector2 Position { get {
                Vector2 currentPos = Ball.GetPosition();
                return currentPos;
            } }
        public override double Radius { get => Ball.GetRadius(); }

        public static void logic_PositionChangeOnData(object sender, Vector2 newPos)
        {
            _logicBall.OnPositionChangeOnLogic(newPos);

        }


    }
}
