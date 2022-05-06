using System.Diagnostics;
using System.Numerics;

namespace Data
{
    internal class Ball : BallAPI
    {
        private Vector2 _position;
        private Vector2 _speed;
        private Vector2 _board;
        private double _weight;
        private double _radius;

        public Ball(Vector2 pos, Vector2 s, double w = 150, double r = 15)
        {
            Position = pos;
            Speed = s;
            Weight = w;
            Radius = r;
            Board = new Vector2(750, 750);

        }

        public Vector2 Position { get => _position; set => _position = value; }
        public override Vector2 getPosition()
        {
            return Position;
        }
        public override void setPosition(Vector2 newPos)
        {
            Position = newPos;
        }
        public Vector2 Speed { get => _speed; set => _speed = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public double Radius { get => _radius; set => _radius = value; }
        public Vector2 Board { get => _board; set => _board = value; }

        public override void move()
        {
            Stopwatch stopwatch = new Stopwatch();
            float movementInterval = 20;
            while (true)
            {
                stopwatch.Start();
                step(movementInterval);
                stopwatch.Stop();
                movementInterval = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

        }

        public override void step(float interval)
        {
            Vector2 newPos = Position + Vector2.Multiply(Speed, interval);
            if (newPos.X < 0) newPos.X = 0;
            if (newPos.Y < 0) newPos.Y = 0;
            if (newPos.X + Radius > Board.X) newPos.X = (float)(Board.X - Radius);
            if (newPos.Y + Radius > Board.Y) newPos.Y = (float)(Board.Y - Radius);
            Position = newPos;
            RaisePropertyChanged("Position");
        }

       

    }
}
