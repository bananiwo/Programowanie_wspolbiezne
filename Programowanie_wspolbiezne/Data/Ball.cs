﻿using System.Diagnostics;
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
            //Speed = rnd.NextDouble() * 1;
            Speed = 20;

            Position = pos;
            Weight = w;
            Radius = r;
            Board = new Vector2(750, 750);
            Debug.WriteLine("Ball");
            Debug.WriteLine(Position);
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


        public override void Step()
        {
            BounceIfHitsWall();
            Vector2 newPos = Position + Vector2.Multiply(Direction, (float)Speed);
            Position = newPos;
            Debug.WriteLine("na dole");
            Debug.WriteLine(newPos.X);
            Debug.WriteLine(newPos.Y);
            OnPositionChangeOnData(newPos);
        }

        private void BounceIfHitsWall()
        {
            double x = Position.X;
            double y = Position.Y;
            if (x <= 0 + Radius || x >= Board.X)
                Direction = new Vector2(-1*Direction.X, Direction.Y);

            if (y <= 0 + Radius || y >= Board.Y)
                Direction = new Vector2(Direction.X, -1*Direction.Y);
        }

        


    }
}
