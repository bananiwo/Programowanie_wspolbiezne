using Data;
using Logic;
using System.Numerics;

namespace PresentationMVM.ViewModel
{
    public class BallVM : ViewModelBase
    {
        private double _radius = 15;
        private LogicLayerAbstractApi _logicLayer;
        private DataLayerAbstractAPI _dataLayer;
        private Vector2 _nextPosition;
        public BallVM(DataLayerAbstractAPI data)
        {
            _dataLayer = data;
            _logicLayer = LogicLayerAbstractApi.CreateObjLogic(750, 750);
            XPos = convertXToCenter(_dataLayer.getX()); //pos x in canvas 
            YPos = convertYToCenter(_dataLayer.getY()); //pos y in canvas
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
                return _dataLayer.getX();
            }
            set
            {
                _dataLayer.setX(value);
                RaisePropertyChanged("XPos");
            }
        }
        public double YPos { 
            get
            {
                return _dataLayer.getY();
            }
            set
            {
                _dataLayer.setY(value);
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
