using Logic;
using System.Diagnostics;
using System.Numerics;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        LogicBallApi _ball;
        private Vector2 _position;
        public BallModel(LogicBallApi ball)
        {
            Ball = ball;
            ball.PositionChangeOnLogic += model_PositionChangeOnLogic;
            Position = ball.Position;
            Debug.WriteLine("ModelBall");
            Debug.WriteLine(Position);

        }

        public void model_PositionChangeOnLogic(object sender, Vector2 newPos)
        {
            OnPositionChangeOnModel(newPos);
        }

        public event EventHandler<Vector2> PositionChangeOnModel;
        protected virtual void OnPositionChangeOnModel(Vector2 newPos)
        {
            PositionChangeOnModel?.Invoke(this, newPos);
        }

        public LogicBallApi Ball { get => _ball; set => _ball = value; }

        public double Radius { get => Ball.Radius; }
        public Vector2 Position { get => _position; set => _position = value; }
    }
}
