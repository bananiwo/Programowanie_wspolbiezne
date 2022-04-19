using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Logic
{
    internal class BallLogic
    {
        private Vector2 boardSize;
        public BallLogic(float X, float Y)
        {
            boardSize = new Vector2(X, Y); //740
        }

        private Vector2 getBallPosition()
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
