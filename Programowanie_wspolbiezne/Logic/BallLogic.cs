using System.Numerics;

namespace Logic
{
    public class BallLogic
    {
        private Vector2 boardSize;

        public BallLogic(float X, float Y) 
        {
            boardSize = new Vector2(X, Y);
        }

        public void ballInit()
        {

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