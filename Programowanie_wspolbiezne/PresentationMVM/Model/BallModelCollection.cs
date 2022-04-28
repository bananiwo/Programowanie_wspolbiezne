using Logic;
namespace PresentationMVM.Model
{
    internal class BallModelCollection
    {
        List<BallModel> _ballModelCollection;
        private LogicApi _logicLayer;
        private LogicCollectionApi _logicCollection;
        public void CreateBallModelCollection(int quantity)
        {
            //_logicCollection = new LogicCollectionApi();
            _logicLayer = LogicApi.CreateObjLogic();
            _logicCollection = LogicCollectionApi.CreateObjCollectionLogic();
            _logicCollection.CreateBallCollection(quantity);
            List<LogicApi> ballCollection = _logicCollection.GetBallCollection();
            _ballModelCollection = new List<BallModel>();
            foreach (LogicApi api in ballCollection)
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

    }
}
