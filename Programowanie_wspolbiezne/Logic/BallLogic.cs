using Data;
using System.Collections.ObjectModel;
using System.Numerics;


namespace Logic
{
    public class BallLogic
    {
        private Vector2 boardSize;
        List<Ball> _ballCollection;

        public BallLogic(float X, float Y) 
        {
            boardSize = new Vector2(X, Y);
        }

        public Ball CreateBall()
        {
            Vector2 ballCoords = getBallPosition();
            return new Ball(ballCoords.X, ballCoords.Y);
        }

        public void CreateBallCollection(int quantity)
        {
            _ballCollection = new List<Ball>();
            for (int i = 0; i < quantity; i++)
            {
                _ballCollection.Add(CreateBall());
            }
        }

        public List<Ball> GetBallCollection()
        {
            return _ballCollection;
        }

        public Vector2 getBallPosition()
        {
            return generatePositionInsideBoard(boardSize);
        }

        private Vector2 generatePositionInsideBoard(Vector2 boardSize)
        {
            Random r = new Random();
            double randomX = r.NextDouble() * boardSize.X;
            double randomY = r.NextDouble() * boardSize.Y;
            randomY += 30;
            return new Vector2((float)randomX, (float)randomY);
        }
    }
}