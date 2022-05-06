using Logic;
using System.Numerics;

namespace PresentationMVM.Model
{
    internal class BallModel
    {
        LogicBallApi _ball;
        public BallModel(LogicBallApi ball)
        {
            Ball = ball;
        }

        public LogicBallApi Ball { get => _ball; set => _ball = value; }

        public Vector2 Position { get => Ball.Position; }
        public double Radius { get => Ball.Radius; }


    }
}
