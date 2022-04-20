using Data;
using Logic;
using System.Numerics;

namespace PresentationMVM.ViewModel
{
    public class BallVM : ViewModelBase
    {
        private double _radius = 15;
        BallLogic _ballLogic;
        Ball originBall;
        private Vector2 _nextPosition;
        public BallVM(Ball ball)
        {
            originBall = ball;
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
                return originBall.X;
            }
            set
            {
                originBall.X = value;
                RaisePropertyChanged("XPos");
            }
        }
        public double YPos { 
            get
            {
                return originBall.Y;
            }
            set
            {
                originBall.Y = value;
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
