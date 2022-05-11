using System.Collections.ObjectModel;
using System.Numerics;

namespace Data
{
    internal class BallCollection : BallCollectionApi
    {
        //List<BallApi> _ballCollection;
        ObservableCollection<BallApi> _ballCollection;
        public BallCollection()
        {
            _ballCollection = new ObservableCollection<BallApi>();
        }

        public override void CreateBallCollection(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Ball ball = new Ball(Ball.GenerateStartPositionInsideBoard());
                _ballCollection.Add(ball);
            }
        }

        public override ObservableCollection<BallApi> GetBallCollection()
        {
            return _ballCollection;
        }

        public override void BallCollectionMovement()
        {
            foreach(Ball ball in _ballCollection)
            {
                ball.Move();
            }
        }
    }
}
