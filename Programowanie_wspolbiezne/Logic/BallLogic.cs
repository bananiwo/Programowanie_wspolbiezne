using Data;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Logic
{
    public class BallLogic : LogicApi
    {
        private Vector2 _boardSize = new Vector2(750, 750);
        private BallAPI _dataLayer;
        private Vector2 _ballCoords;
        private Vector2 _ballVelocity;

        public Vector2 BoardSize { get => _boardSize; set => _boardSize = value; }

        public BallLogic() 
        {
            _dataLayer = BallAPI.CreateObject();
        }

        public override BallAPI GetDataAPI()
        {
            return _dataLayer;
        }
        
        public override Vector2 GetPosition()
        {
            return _dataLayer.getPosition();
        }

        public override void SetPosition(Vector2 newPos)
        {
            _dataLayer.setPosition(newPos);
        }

        public override void moveBallLogic()
        {
            _dataLayer.move();
        }

        public override LogicApi CreateBall()
        {
            _dataLayer = BallAPI.CreateObject();
            return LogicApi.CreateObjLogic(_dataLayer);
        }
    }
}