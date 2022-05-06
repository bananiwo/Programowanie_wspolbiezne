using System.Numerics;

namespace Data
{
    internal class BallCollection : BallCollectionAPI
    {
        List<BallAPI> _ballCollection;
        public override void CreateBallCollection(int quantity)
        {
            _ballCollection = new List<BallAPI>();
            for (int i = 0; i < quantity; i++)
            {
                Ball ball = new Ball(Ball.GenerateStartPositionInsideBoard(), Ball.GenerateStartSpeed());
                _ballCollection.Add(ball);
            }
        }

        public override List<BallAPI> GetBallCollection()
        {
            return _ballCollection;
        }
    }
}
