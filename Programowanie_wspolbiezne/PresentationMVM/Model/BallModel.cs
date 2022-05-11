using Logic;
using System.Numerics;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        LogicBallApi _ball;
        public BallModel(LogicBallApi ball)
        {
            Ball = ball;
            Ball.PositionChangedLogic += bl_PositionChangedLogic;

        }
        public static void bl_PositionChangedLogic(object sender, Vector2 pos)
        {
            Console.WriteLine(pos);
        }

        public event EventHandler<Vector2> PositionChangedModel;
        protected virtual void OnPositionChangedModel(Vector2 newPosition)
        {
            PositionChangedModel?.Invoke(this, newPosition);
        }

        public LogicBallApi Ball { get => _ball; set => _ball = value; }

        public Vector2 Position { get { Vector2 currentPos = Ball.Position; 
                OnPositionChangedModel(currentPos);
                return currentPos;
            } }
        public double Radius { get => Ball.Radius; }


    }
}
