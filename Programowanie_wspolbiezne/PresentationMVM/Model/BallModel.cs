using Logic;
using System.Numerics;
using System.Diagnostics;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        private LogicApi _logicLayer;
        private double _xPosModelBall;
        private double _yPosModelBall;
        
        public BallModel()
        {
            Debug.WriteLine("Wydruk na konsole");
            _logicLayer = LogicApi.CreateObjLogic();
            _xPosModelBall = _logicLayer.GetCurrentBallPosition().X; //pos x in canvas 
            _yPosModelBall = _logicLayer.GetCurrentBallPosition().Y; //pos y in canvas
        }

        public double xPosModelBall
        {
            get
            {
                return _logicLayer.GetCurrentBallPosition().X;
            }
            set
            {
                _logicLayer.SetCurrentBallPositionX(value);
            }
        }

        public double yPosModelBall
        {
            get
            {
                return _logicLayer.GetCurrentBallPosition().Y;
            }
            set
            {
                _logicLayer.SetCurrentBallPositionY(value);
            }
        }

        public Vector2 getPosModelBall()
        {
            return new Vector2((float)xPosModelBall, (float)xPosModelBall);
        }

        public Vector2 GetBallPosition()
        {
            return _logicLayer.GeneratePositionInsideBoard();
        }

    }
}
