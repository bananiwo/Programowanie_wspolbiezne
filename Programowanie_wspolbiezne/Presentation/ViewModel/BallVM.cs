using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
    public class BallVM
    {

        private double _radius = 15;
        public BallVM(double x, double y)
        {

            Left = convertXToCenter(x);
            Bottom = convertYToCenter(y);
        }

        public BallVM()
        {
            Random r = new Random();
            double randomX = r.NextDouble() * (780 - 2 * _radius);
            randomX +=  _radius;

            r = new Random();
            double randomY = r.NextDouble() * (780 - 2 * _radius);
            randomY += 10 + _radius;

            Left = convertXToCenter(randomX);
            Bottom = convertYToCenter(randomY);
        }

        private double convertXToCenter(double x)
        {
            return x + _radius;
        }

        private double convertYToCenter(double y)
        {
            return y - _radius;
        }
        public double BallDiameter
        {
            get
            {
                return _radius * 2;
            }
        }
        public double Left { get; set; }
        public double Bottom { get; set; }
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }
    }
}
