using System;
using System.Collections.ObjectModel;
using Data;
using Logic;
using System.Windows;
using System.Numerics;

namespace Presentation.ViewModel
{
    public class BallVM
    {
        private double _radius = 15;
        BallLogic _ballLogic;
        Ball originBall;
        public BallVM(Ball ball)
        {
            originBall = ball;
            _ballLogic = new BallLogic(750, 750);
            Left = convertXToCenter(ball.X); //pos x in canvas 
            Bottom = convertYToCenter(ball.Y); //pos y in canvas

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

        public void updatePosOnCanvas()
        {
            Vector2 newPos = _ballLogic.GetBallPosition();
            MessageBox.Show(newPos.X.ToString() + ',' + newPos.Y.ToString());
            Left = convertXToCenter(newPos.X);
            Bottom = convertYToCenter(newPos.Y);
            originBall.X = newPos.X;
            originBall.Y = newPos.Y;
            
        }
    }
}
