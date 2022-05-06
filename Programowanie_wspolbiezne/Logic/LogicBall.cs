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
        }

        public BallApi Ball { get => _ball; set => _ball = value; }

        public override Vector2 Position { get => Ball.GetPosition(); }
        public override double Radius { get => Ball.GetRadius(); }

    
    }
}
