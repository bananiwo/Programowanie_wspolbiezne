using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Ball : DataAPI
    {
        private double _x;
        private double _y;

        public Ball(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override double getX()
        {
            return _x;
        }

        public override double getY()
        {
            return _y;
        }

        public override void setX(double newX)
        {
            _x = newX;
        }

        public override void setY(double newY)
        {
            _y = newY;
        }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
    }
}
