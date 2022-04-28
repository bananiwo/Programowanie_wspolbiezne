using Data;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Logic
{
    public class BallLogic : LogicApi
    {
        private Vector2 _boardSize = new Vector2(750, 750);
        private double _ballXPos;
        private double _ballYPos;
        private DataAPI _dataLayer;
        

        public BallLogic() 
        {
            Vector2 ballCoords = GeneratePositionInsideBoard();
            _dataLayer = DataAPI.CreateObject(ballCoords.X, ballCoords.Y);
        }


        public override DataAPI GetDataAPI()
        {
            return _dataLayer;
        }
        

        public override Vector2 GetCurrentBallPosition()
        {
            return new Vector2((float) _dataLayer.getX(), (float)_dataLayer.getY()); 
        }

        public override void SetCurrentBallPositionX(double xPos)
        {
            _dataLayer.setX(xPos);
        }

        public override void SetCurrentBallPositionY(double yPos)
        {
            _dataLayer.setY(yPos);
        }

        public override Vector2 GeneratePositionInsideBoard()
        {
            Random r = new Random();
            double randomX = r.NextDouble() * _boardSize.X;
            r = new Random();
            double randomY = r.NextDouble() * _boardSize.Y;
            randomY += 30;
            return new Vector2((float)randomX, (float)randomY);
        }

        public override Vector2 NextStepPosition(Vector2 currentPos, Vector2 targetPos, int stepCount)
        {
            Vector2 desiredMovement = targetPos - currentPos;
            return currentPos + (desiredMovement / stepCount);
        }

        public override LogicApi CreateBall()
        {
            Vector2 ballCoords = GeneratePositionInsideBoard();
            _dataLayer = DataAPI.CreateObject(ballCoords.X, ballCoords.Y);
            _ballXPos = ballCoords.X;
            _ballYPos = ballCoords.Y;
            return LogicApi.CreateObjLogic(_dataLayer);
        }
    }
}