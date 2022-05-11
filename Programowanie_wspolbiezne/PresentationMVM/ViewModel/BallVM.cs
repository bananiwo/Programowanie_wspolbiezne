using PresentationMVM.Model;
using System.Diagnostics;
using System.Numerics;

namespace PresentationMVM.ViewModel
{
    public class BallVM : ViewModelBase
    {
        static double _x;
        static double _y;
        static BallVM _ballVM;
        double _radius;
        static Vector2 positionFromMove;

        public double Radius { get => _radius; set => _radius = value; }
        public static double X { get => _x; 
            set { 
                _x = value;
                _ballVM.RaisePropertyChanged("X");
            } 
        }
        public static double Y { get => _y; 
            set { 
                _y = value;
                _ballVM.RaisePropertyChanged("Y");
            } 
        }

        public BallVM(BallModel ball)
        {
            _ballVM = this;
            X = ball.Position.X;
            Y = ball.Position.Y;
            Radius = ball.Radius;
            ball.PositionChangeOnModel += vm_PositionChangeOnModel;
        }

        public static void vm_PositionChangeOnModel(object sender, Vector2 newPos)
        {
            Debug.WriteLine(X);
            Debug.WriteLine(Y);
            X = newPos.X;
            _ballVM.RaisePropertyChanged("X");
            Y = newPos.Y;
            _ballVM.RaisePropertyChanged("Y");

        }

    }
}
