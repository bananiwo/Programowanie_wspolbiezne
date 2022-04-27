using Logic;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        private LogicApi _logicLayer;
        private double _xPosModelBall;
        private double _yPosModelBall;
        //private List<LogicApi> _ballCollection;
        public BallModel()
        {
            _logicLayer = LogicApi.CreateObjLogic(740, 740);
            _xPosModelBall = _logicLayer.GetCurrentBallPosition().X; //pos x in canvas 
            _yPosModelBall = _logicLayer.GetCurrentBallPosition().Y; //pos y in canvas

            //_logicLayer.CreateBallCollection(ballCount);
            //_ballCollection = _logicLayer.GetBallCollection();
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


        /*public List<LogicApi> GetBallCollection()
        {
            return _ballCollection;
        }*/

    }
}
