using Data;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Logic
{
    public class BallLogic : LogicApi
    {
        private Vector2 _boardSize = new Vector2(750, 750);
        private DataAPI _dataLayer;

        public Vector2 BoardSize { get => _boardSize; set => _boardSize = value; }

        public BallLogic() 
        {
            Vector2 ballCoords = GenerateStartPositionInsideBoard();
            Vector2 ballVelocity = new Vector2(10, 10);
            _dataLayer = DataAPI.CreateObject(ballCoords, ballVelocity, BoardSize);
        }

        public override DataAPI GetDataAPI()
        {
            return _dataLayer;
        }
        

        public override Vector2 GetCurrentBallPosition()
        {
            return _dataLayer.getPosition();
        }

        public override void SetCurrentBallPosition(Vector2 newPos)
        {
            _dataLayer.setPosition(newPos);
        }


        public override Vector2 GenerateStartPositionInsideBoard()
        {
            Random r = new Random();
            double randomX = r.NextDouble() * BoardSize.X;
            r = new Random();
            double randomY = r.NextDouble() * BoardSize.Y;
            randomY += 30;
            return new Vector2((float)randomX, (float)randomY);
        }

        public override void moveBallLogic()
        {
            /*Vector2 desiredMovement = targetPos - currentPos;
            return currentPos + (desiredMovement / stepCount);*/
            _dataLayer.move();
        }

        public override LogicApi CreateBall()
        {
            Vector2 ballCoords = GenerateStartPositionInsideBoard();
            Vector2 ballVelocity = new Vector2(10, 10);
            _dataLayer = DataAPI.CreateObject(ballCoords, ballVelocity, BoardSize);
            return LogicApi.CreateObjLogic(_dataLayer);
        }
    }
}