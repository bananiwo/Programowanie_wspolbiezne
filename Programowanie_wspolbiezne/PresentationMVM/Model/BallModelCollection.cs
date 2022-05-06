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
            _logicLayer = LogicApi.CreateObjLogic();
            _logicCollection = LogicCollectionApi.CreateObjCollectionLogic();
            _logicCollection.CreateBallLogicCollection(quantity);
            List<LogicApi> ballCollection = _logicCollection.GetBallLogicCollection();
            _ballModelCollection = new List<BallModel>();
            foreach (LogicApi api in ballCollection)
                {
                    BallModel ballModel = new BallModel();
                    _ballModelCollection.Add(ballModel);
                    ballModel.Position = _logicLayer.GetPosition();
                }
        }

        public List<BallModel> GetBallModelCollection()
        {
            return _ballModelCollection;
        }

    }
}
