using Logic;
using Data;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        private LogicLayerAbstractApi _logicLayer;
        private List<DataLayerAbstractAPI> _ballCollection;
        public BallModel(int ballCount)
        {
            _logicLayer = LogicLayerAbstractApi.CreateObjLogic(740, 740);
            _logicLayer.CreateBallCollection(ballCount);
            _ballCollection = _logicLayer.GetBallCollection();
        }

        public List<DataLayerAbstractAPI> GetBallCollection()
        {
            return _ballCollection;
        }
    }
}
