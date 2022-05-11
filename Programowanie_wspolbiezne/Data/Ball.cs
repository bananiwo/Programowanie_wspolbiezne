using System.Diagnostics;
using System.Numerics;

namespace Data
{
    internal class Ball : BallApi
    {
        private Vector2 _position;
        private Vector2 _speed;
        private Vector2 _board;
        private double _weight;
        private double _radius;
        public event EventHandler<Vector2> PositionChanged;
         
        public Ball(Vector2 pos, Vector2 s, double w = 150, double r = 15)
        {
            Position = pos;
            Speed = s;
            Weight = w;
            Radius = r;
            Board = new Vector2(750, 750);

        }

        protected virtual void OnPositionChanged(Vector2 NewPosition)
        {
            PositionChanged?.Invoke(this, NewPosition);
        }

        public Vector2 Position { get => _position;
            set
            {
                _position = value;
                OnPositionChanged(_position);
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
        public override double GetRadius()
        {
            return Radius;
        }
        public Vector2 Speed { get => _speed; set => _speed = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public double Radius { get => _radius; set => _radius = value; }
        public Vector2 Board { get => _board; set => _board = value; }

        public override void Move()
        {
            Stopwatch stopwatch = new Stopwatch();
            float movementInterval = 20;
            //while (true)
            //{
            //    stopwatch.Start();
            //    Step(movementInterval);
            //    stopwatch.Stop();
            //    movementInterval = stopwatch.ElapsedMilliseconds;
            //    stopwatch.Reset();
            //}

        }

        public override void Step(float interval)
        {
            Vector2 newPos = Position + Vector2.Multiply(Speed, interval);
            if (newPos.X < 0) newPos.X = 0;
            if (newPos.Y < 0) newPos.Y = 0;
            if (newPos.X + Radius > Board.X) newPos.X = (float)(Board.X - Radius);
            if (newPos.Y + Radius > Board.Y) newPos.Y = (float)(Board.Y - Radius);
            Position = newPos;
            //RaisePropertyChanged("Position");
        }

       

    }
}
