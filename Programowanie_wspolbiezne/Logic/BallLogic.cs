using Data;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Logic
{
    public class BallLogic
    {
        private Vector2 boardSize;
        private int speed;
        List<Ball> _ballCollection;

        public BallLogic(float X, float Y) 
        {
            boardSize = new Vector2(X, Y);
            speed = 0;
        }

        public BallLogic()
        {
            
        }

        public Ball CreateBall()
        {
            Vector2 ballCoords = GetBallPosition();
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

        public Vector2 GetBallPosition()
        {
            return GeneratePositionInsideBoard(boardSize);
        }

        private Vector2 GeneratePositionInsideBoard(Vector2 boardSize)
        {
            Random r = new Random();
            double randomX = r.NextDouble() * boardSize.X;
            r = new Random();
            double randomY = r.NextDouble() * boardSize.Y;
            randomY += 30;
            return new Vector2((float)randomX, (float)randomY);
        }

    }
}