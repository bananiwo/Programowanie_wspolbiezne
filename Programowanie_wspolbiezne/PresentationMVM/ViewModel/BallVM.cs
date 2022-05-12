using PresentationMVM.Model;
using System.Diagnostics;
using System.Numerics;

namespace PresentationMVM.ViewModel
{
    public class BallVM : ViewModelBase
    {
        static double _x;
        static double _y;
        string _uuid;
        static BallVM _ballVM;
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

        public BallVM(BallModel ball)
        {
            _ballVM = this;
            Guid myUUId = Guid.NewGuid();
            _uuid = myUUId.ToString();
            X = ball.Position.X;
            Y = ball.Position.Y;
            Radius = ball.Radius;
            ball.PositionChangeOnModel += vm_PositionChangeOnModel;
            Debug.WriteLine("BallVM");
            Debug.WriteLine(X);
            Debug.WriteLine(Y);
        }

        public event EventHandler<Vector2> PositionChangeOnBallVM;
        protected virtual void OnPositionChangeOnModel(Vector2 newPos)
        {
            PositionChangeOnBallVM.Invoke(this, newPos);
        }

        public static void vm_PositionChangeOnModel(object sender, Vector2 newPos)
        {
            ControlsViewModel.ChangeBallVMPosition(_ballVM, newPos);

        }

    }
}
