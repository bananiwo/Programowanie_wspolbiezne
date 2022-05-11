using PresentationMVM.Model;
using System.Diagnostics;
using System.Numerics;

namespace PresentationMVM.ViewModel
{
    public class BallVM : ViewModelBase
    {
        static double _x;
        static double _y;
        double _radius;
        static Vector2 positionFromMove;

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

        public BallVM(BallModel ball)
        {
            X = ball.Position.X;
            Y = ball.Position.Y;
            Radius = ball.Radius;
            ball.PositionChangeOnModel += vm_PositionChangeOnModel;
            
        }

        public static void vm_PositionChangeOnModel(object sender, Vector2 newPos)
        {
            _x = newPos.X;
            _y = newPos.Y;
           
        }

    }
}
