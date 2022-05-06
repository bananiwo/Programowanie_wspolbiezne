using Logic;
using System.Numerics;
using System.Diagnostics;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        private LogicApi _logicLayer;
        private Vector2 _positionBallModel;

        
        public BallModel()
        {
            _logicLayer = LogicApi.CreateObjLogic();
        }

        public Vector2 Position { get => _positionBallModel; set => _positionBallModel = value; }

        public Vector2 getPosModelBall()
        {
            return Position;
        }


    }
}
