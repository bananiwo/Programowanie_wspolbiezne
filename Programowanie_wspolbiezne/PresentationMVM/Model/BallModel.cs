using Logic;
using System.Numerics;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        private LogicApi _logicLayer;
        private double _xPosModelBall;
        private double _yPosModelBall;
        List<BallModel> _ballModelCollection;
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

        public Vector2 getPosModelBall()
        {
            return new Vector2((float)xPosModelBall, (float)xPosModelBall);
        }

        public Vector2 GetBallPosition()
        {
            return _logicLayer.GeneratePositionInsideBoard();
        }

        public void CreateBallModelCollection(int quantity)
        {
            _logicLayer.CreateBallCollection(quantity);
            List<LogicApi> ballCollection = _logicLayer.GetBallCollection();
            _ballModelCollection = new List<BallModel>();
            foreach(LogicApi api in ballCollection)
            for (int i = 0; i < quantity; i++)
            {
                BallModel ballModel = new BallModel();
                _ballModelCollection.Add(ballModel);
                ballModel.xPosModelBall = _logicLayer.GetCurrentBallPosition().X;
                ballModel.yPosModelBall = _logicLayer.GetCurrentBallPosition().Y;
            }
        }

        public List<BallModel> GetBallModelCollection()
        {
            return _ballModelCollection;
        }

        /*public List<LogicApi> GetBallCollection()
        {
            return _ballCollection;
        }*/

    }
}
