using System.Collections.ObjectModel;
using System.Numerics;

namespace Data
{
    internal class BallCollection : BallCollectionApi
    {
        List<BallApi> _ballCollection;
        public BallCollection()
        {
            _ballCollection = new List<BallApi>();
        }

        public override void CreateBallCollection(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Task task = Task.Factory.StartNew(createBall);
            }
        }

        private void createBall()
        {
            Ball ball = new Ball(Ball.GenerateStartPositionInsideBoard());
            _ballCollection.Add(ball);
        }

        public override List<BallApi> GetBallCollection()
        {
            return _ballCollection;
        }

    }
}
