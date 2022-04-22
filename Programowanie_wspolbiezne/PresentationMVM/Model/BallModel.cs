using Logic;
using Data;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        private LogicApi _logicLayer;
        private List<DataAPI> _ballCollection; //niezbyt
        public BallModel(int ballCount)
        {
            _logicLayer = LogicApi.CreateObjLogic(740, 740);
            _logicLayer.CreateBallCollection(ballCount);
            _ballCollection = _logicLayer.GetBallCollection();
        }

        public List<DataAPI> GetBallCollection()
        {
            return _ballCollection;
        }
    }
}
