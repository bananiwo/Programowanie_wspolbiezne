using Data;
using Logic;
using PresentationMVM.Model;
using System.Numerics;

namespace PresentationMVM.ViewModel
{
    public class BallVM : ViewModelBase
    {

        //tu gdzies trzeba dodac budowanie obiektów BallVM albo w viemodel
        private double _radius = 15;
        private BallModel _ballModel;
        private Vector2 _posBallVM;
        private double _xPosBallVM;
        private double _yPosBallVM;

        public Vector2 NextPosition { get; set; }
        public Vector2 NextStepVector { get; set; }

        public BallVM() 
        {
            _ballModel = new BallModel();
        }
        public BallVM(BallModel ballModel)
        {
            PosBallVM = ballModel.Position;
            XPosBallVM = PosBallVM.X;
            YPosBallVM = PosBallVM.Y;
            _ballModel = new BallModel();
        }


        public double BallDiameter
        {
            get
            {
                return _radius * 2;
            }
        }

        public Vector2 PosBallVM { get 
            { 
                return _posBallVM; 
            }
            set 
            { 
                _posBallVM = value;
                XPosBallVM = value.X;
                YPosBallVM = value.Y;
                RaisePropertyChanged("PosBallVM");
            } 
        }



        public Vector2 getPosBallVM()
        {
            return PosBallVM;
        }

        public Vector2 GetBallVMPosition()
        {
            return _ballModel.GetBallPosition();
        }

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

        public double XPosBallVM { get => _xPosBallVM; set => _xPosBallVM = value; }
        public double YPosBallVM { get => _yPosBallVM; set => _yPosBallVM = value; }
    }
}
