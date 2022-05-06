using System.Numerics;

namespace PresentationMVM.ViewModel
{
    public class BallVM : ViewModelBase
    {
        double _x;
        double _y;
        double _radius;

        public double Radius { get => _radius; set => _radius = value; }
        public double X { get => _x; 
            set { 
                _x = value;
                RaisePropertyChanged("X");
            } 
        }
        public double Y { get => _y; 
            set { 
                _y = value;
                RaisePropertyChanged("Y");
            } 
        }

        public BallVM(double x = 0, double y = 0, double r = 0)
        {
            X = x;
            Y = y;
            Radius = r;
        }
    }
}
