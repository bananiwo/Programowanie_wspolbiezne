using System;
using System.Collections.ObjectModel;
using Data;
using Logic;
using System.Windows;


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
