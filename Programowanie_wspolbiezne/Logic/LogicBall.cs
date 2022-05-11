using Data;
using System.Numerics;

namespace Logic
{
    internal class LogicBall : LogicBallApi
    {
        BallApi _ball;
        public LogicBall(BallApi ball)
        {
            Ball = ball;
            Ball.PositionChanged += bl_PositionChanged;
        }
        public static void bl_PositionChanged(object sender, Vector2 pos)
        {
            Console.WriteLine(pos);
        }

        public BallApi Ball { get => _ball; set => _ball = value; }

        public override Vector2 Position { get {
                Vector2 currentPos = Ball.GetPosition();
                OnPositionChangedLogic(currentPos);
                return currentPos;
            } }
        public override double Radius { get => Ball.GetRadius(); }

    
    }
}
