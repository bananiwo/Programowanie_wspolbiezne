using Logic;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        private LogicApi _logicLayer;
        private List<LogicApi> _ballCollection;
        public BallModel(int ballCount)
        {
            _logicLayer = LogicApi.CreateObjLogic(740, 740);
            _logicLayer.CreateBallCollection(ballCount);
            _ballCollection = _logicLayer.GetBallCollection();
        }

        public List<LogicApi> GetBallCollection()
        {
            return _ballCollection;
        }

    }
}
