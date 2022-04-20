using Logic;
using Data;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        private BallLogic _ballLogic;
        private List<Ball> _ballCollection;
        public BallModel(int ballCount)
        {
            _ballLogic = new BallLogic(740, 740);
            _ballLogic.CreateBallCollection(ballCount);
            _ballCollection = _ballLogic.GetBallCollection();
        }

        public List<Ball> GetBallCollection()
        {
            return _ballCollection;
        }
    }
}
