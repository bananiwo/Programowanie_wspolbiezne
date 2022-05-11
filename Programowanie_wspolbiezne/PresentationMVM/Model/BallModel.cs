using Logic;
using System.Numerics;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        LogicBallApi _ball;
        static BallModel _ballModel;
        public BallModel(LogicBallApi ball)
        {
            Ball = ball;
            _ballModel = this;
            ball.PositionChangeOnLogic += model_PositionChangeOnLogic;

        }

        public static void model_PositionChangeOnLogic(object sender, Vector2 newPos)
        {
            _ballModel.OnPositionChangeOnModel(newPos);
        }

        public event EventHandler<Vector2> PositionChangeOnModel;
        protected virtual void OnPositionChangeOnModel(Vector2 newPos)
        {
            PositionChangeOnModel?.Invoke(this, newPos);
        }

        public LogicBallApi Ball { get => _ball; set => _ball = value; }

        public Vector2 Position { get { Vector2 currentPos = Ball.Position; 
                return currentPos;
            } }
        public double Radius { get => Ball.Radius; }


    }
}
