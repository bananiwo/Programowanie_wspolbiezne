using System.Numerics;

namespace Data
{
    public abstract class BallApi : DataBase

    {
        public abstract void Move();
        public abstract void Step(float interval);
        public abstract Vector2 GetPosition();
        public abstract Vector2 GetDirection();
        public abstract double GetSpeed();
        public abstract double GetRadius();
        public abstract void SetPosition(Vector2 newPos);
        public abstract void SetDirection(Vector2 newDir);
        public abstract void SetSpeed(double newSpeed);
        public static BallApi CreateObject()
        {
            return new Ball(GenerateStartPositionInsideBoard());
        }


        public static Vector2 GenerateStartPositionInsideBoard()
        {
            Vector2 boardSize = new Vector2(750, 750);
            Random r = new Random();
            double randomX = r.NextDouble() * boardSize.X;
            r = new Random();
            double randomY = r.NextDouble() * boardSize.Y;
            randomY += 30;
            return new Vector2((float)randomX, (float)randomY);
        }
    }
}
