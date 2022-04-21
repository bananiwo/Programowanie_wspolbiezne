using Data;
using Logic;
using System.Numerics;

namespace PresentationMVM.ViewModel
{
    public class BallVM : ViewModelBase
    {
        private double _radius = 15;
        private BallLogic _ballLogic;
        private Ball _originBall;
        private Vector2 _nextPosition;
        public BallVM(Ball ball)
        {
            _originBall = ball;
            _ballLogic = new BallLogic(750, 750);
            XPos = convertXToCenter(ball.X); //pos x in canvas 
            YPos = convertYToCenter(ball.Y); //pos y in canvas
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
                return _originBall.X;
            }
            set
            {
                _originBall.X = value;
                RaisePropertyChanged("XPos");
            }
        }
        public double YPos { 
            get
            {
                return _originBall.Y;
            }
            set
            {
                _originBall.Y = value;
                RaisePropertyChanged("YPos");
            }
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
