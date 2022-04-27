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
        private double _xPosBallVM;
        private double _yPosBallVM;
        //private LogicApi _logicLayer;
        private Vector2 _nextPosition;
        public BallVM()
        {
            _ballModel = new BallModel();
            //_logicLayer = LogicApi.CreateObjLogic(750, 750);
            _xPosBallVM = _ballModel.xPosModelBall; //pos x in canvas 
            _yPosBallVM = _ballModel.yPosModelBall; //pos y in canvas
        }

        public Vector2 NextPosition { get; set; }
        public Vector2 NextStepVector { get; set; }

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
        public double XPos { get
            {
                return _ballModel.xPosModelBall;
            }
            set
            {
                _ballModel.xPosModelBall = value;
                RaisePropertyChanged("XPos");
            }
        }
        public double YPos { 
            get
            {
                return _ballModel.yPosModelBall;
            }
            set
            {
                _ballModel.yPosModelBall = value;
                RaisePropertyChanged("YPos");
            }
        }

        public Vector2 getPosBallVM()
        {
            return new Vector2((float)XPos, (float)YPos);
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
    }
}
