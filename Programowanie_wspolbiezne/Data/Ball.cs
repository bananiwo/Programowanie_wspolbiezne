using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Ball : DataAPI
    {
        private double _x;
        private double _y;
        private double _weight = 150;
        private double _radius = 15;
        private double _xSpeed = 10;
        private double _ySpeed = 10;

        public Ball(double x, double y)
        {
            X = x;
            Y = y;
        }

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
            Vector2 currentPos = new Vector2();
            currentPos.X = (float)X;
            currentPos.Y = (float)Y;
            Vector2 speed = new Vector2();
            speed.X = (float)XSpeed;
            speed.Y = (float)YSpeed;
            Vector2 newPos = currentPos + Vector2.Multiply(speed, interval);
            if (newPos.X < 0) newPos.X = -1;
            if (newPos.Y < 0) newPos.Y = -1;
            //750 - rozmiar okna jakos ttu trzeba dostarczyc
            if (newPos.X + Radius > 750) newPos.X = (float)(750 - Radius);
            if (newPos.Y + Radius > 750) newPos.Y = (float)(750 - Radius);
            X = newPos.X;
            RaisePropertyChanged("_x");
            Y = newPos.Y;
            RaisePropertyChanged("_y");
        }


        public override double getX()
        {
            return X;
        }

        public override double getY()
        {
            return Y;
        }

        public override void setX(double newX)
        {
            X = newX;
        }

        public override void setY(double newY)
        {
            Y = newY;
        }

        public double Weight { get => _weight; set => _weight = value; }
        public double Radius { get => _radius; set => _radius = value; }
        public double XSpeed { get => _xSpeed; set => _xSpeed = value; }
        public double YSpeed { get => _ySpeed; set => _ySpeed = value; }
        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
    }
}
