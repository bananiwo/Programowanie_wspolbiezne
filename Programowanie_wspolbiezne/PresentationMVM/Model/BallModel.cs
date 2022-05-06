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
            Vector2 pos = new Vector2(_logicLayer.GetCurrentBallPosition().X, _logicLayer.GetCurrentBallPosition().Y);
            Position = pos; //pos in canvas
        }


        public Vector2 Position { get => _positionBallModel; set => _positionBallModel = value; }

        public Vector2 getPosModelBall()
        {
            return Position;
        }

        public Vector2 GetBallPosition()
        {
            return _logicLayer.GenerateStartPositionInsideBoard();
        }

    }
}
