using Data;
using System.Diagnostics;
using System.Numerics;

namespace Logic
{
    internal class LogicBall : LogicBallApi
    {
        BallApi _ball;
        Vector2 _logicPosition;
        public LogicBall(BallApi ball)
        {
            Ball = ball;
            
            Ball.PositionChangeOnData += logic_PositionChangeOnData;

        }

        public LogicBall()
        {
            Ball.PositionChangeOnData += logic_PositionChangeOnData;
            Debug.WriteLine("konstruk");
        }


        public BallApi Ball { get => _ball; set => _ball = value; }

        public override Vector2 Position { get {
                Vector2 currentPos = Ball.GetPosition();
                return currentPos;
            } }
        public override double Radius { get => Ball.GetRadius(); }

        public static void logic_PositionChangeOnData(object sender, Vector2 newPos)
        {
            LogicBall logic = new LogicBall();
            logic.OnPositionChangeOnLogic(newPos);
            Debug.WriteLine("jestem");

        }


    }
}
