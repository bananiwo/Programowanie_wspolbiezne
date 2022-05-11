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
            ball.PositionChangeOnLogic += model_PositionChangeOnLogic;

        }

        public BallModel()
        {

        }

        public static void model_PositionChangeOnLogic(object sender, Vector2 newPos)
        {
            BallModel model= new BallModel();
            model.OnPositionChangeOnModel(newPos);
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
