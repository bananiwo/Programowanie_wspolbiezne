using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
    public class BallVM
    {

        private double _radius = 25;
        public BallVM(double x, double y)
        {

            Left = convertXToCenter(x);
            Bottom = convertYToCenter(y);
        }

        public BallVM()
        {
            Random r = new Random();
            double randomX = r.NextDouble() * (780 - 2 * Radius);
            randomX +=  Radius;

            r = new Random();
            double randomY = r.NextDouble() * (780 - 2 * Radius);
            randomY += 10 + Radius;

            Left = convertXToCenter(randomX);
            Bottom = convertYToCenter(randomY);
        }

        private Double convertXToCenter(double x)
        {
            return x + Radius;
        }

        private Double convertYToCenter(double y)
        {
            return y - Radius;
        }

        public Double Left { get; set; }
        public Double Bottom { get; set; }
        public Double Radius
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
