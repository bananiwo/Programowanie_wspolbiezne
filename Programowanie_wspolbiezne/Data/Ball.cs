using System.Diagnostics;
using System.Numerics;

namespace Data
{
    internal class Ball : BallApi
    {
        private Vector2 _position;
        private Vector2 _direction;
        private Vector2 _board;
        private double _speed;
        private double _weight;
        private double _radius;
         
        public Ball(Vector2 pos, double w = 150, double r = 15)
        {
            Random rnd = new Random();
            double x = rnd.NextDouble() * 2 - 1;
            double y = rnd.NextDouble() * 2 - 1;
            Direction = new Vector2((float)x, (float)y);
            Direction = Vector2.Normalize(Direction);
            Speed = rnd.NextDouble() * 1;

            Position = pos;
            Weight = w;
            Radius = r;
            Board = new Vector2(750, 750);
        }


        public Vector2 Position { get => _position;
            set
            {
                _position = value;
            }
        }
        public override Vector2 GetPosition()
        {
            return Position;
        }
        public override void SetPosition(Vector2 newPos)
        {
            Position = newPos;
        }
        public override Vector2 GetDirection()
        {
            return Direction;
        }
        public override void SetDirection(Vector2 newDir)
        {
            Direction = newDir;
        }
        public override double GetSpeed()
        {
            return Speed;
        }
        public override void SetSpeed(double newSpeed)
        {
            Speed = newSpeed;
        }
        public override double GetRadius()
        {
            return Radius;
        }
        public double Speed { get => _speed; set => _speed = value; }
        public Vector2 Direction { get => _direction; set => _direction = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public double Radius { get => _radius; set => _radius = value; }
        public Vector2 Board { get => _board; set => _board = value; }

        public override void Move()
        {
            float movementInterval = 20;
            for (int i = 0; i < 10000; i++)
            {
                Step(movementInterval/1000);
            }

        }

        public override void Step(float interval)
        {
            Vector2 newPos = Position + Vector2.Multiply(Vector2.Multiply(Direction, (float)Speed), interval);
            if (newPos.X < 0) newPos.X = 0;
            if (newPos.Y < 0) newPos.Y = 0;
            if (newPos.X + Radius > Board.X) newPos.X = (float)(Board.X - Radius);
            if (newPos.Y + Radius > Board.Y) newPos.Y = (float)(Board.Y - Radius);
            Position = newPos;
            Debug.WriteLine(Position);
            OnPositionChangeOnData(newPos);
        }

        


    }
}
