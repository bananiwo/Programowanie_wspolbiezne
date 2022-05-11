using System.Numerics;

namespace Data
{
    public abstract class BallApi 

    {
        public abstract void Move();
        public abstract void Step(float interval);
        public abstract Vector2 GetPosition();
        public abstract double GetRadius();
        public abstract void SetPosition(Vector2 newPos);
        public static BallApi CreateObject()
        {
            return new Ball(GenerateStartPositionInsideBoard(), GenerateStartSpeed());
        }

        public event EventHandler<Vector2> PositionChanged;
        protected virtual void OnPositionChanged(Vector2 newPosition)
        {
            PositionChanged?.Invoke(this, newPosition);
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

        public static Vector2 GenerateStartSpeed()
        {
            Vector2 startSpeed = new Vector2();
            Random r = new Random();
            double startSpeedX = r.NextDouble() * 3;
            r = new Random();
            double startSpeedY = r.NextDouble() * 3;
            return new Vector2((float)startSpeedX, (float)startSpeedY);
        }
    }
}
