﻿using Data;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Logic
{
    public class BallLogic : LogicApi
    {
        private Vector2 _boardSize;
        private DataAPI _dataLayer;
        List<DataAPI> _ballCollection;

        public BallLogic(float X, float Y) 
        {
            _boardSize = new Vector2(X, Y);
        }

        public override DataAPI CreateBall()
        {
            Vector2 ballCoords = GetBallPosition();
            _dataLayer = DataAPI.CreateObject(ballCoords.X, ballCoords.Y);
            return _dataLayer;
            //return new Ball(ballCoords.X, ballCoords.Y);
        }

        public override void CreateBallCollection(int quantity)
        {
            _ballCollection = new List<DataAPI>();
            for (int i = 0; i < quantity; i++)
            {
                _ballCollection.Add(CreateBall());
            }
        }

        public override List<DataAPI> GetBallCollection()
        {
            return _ballCollection;
        }
        public override Vector2 GetBallPosition()
        {
            return GeneratePositionInsideBoard(_boardSize);
        }

        private Vector2 GeneratePositionInsideBoard(Vector2 boardSize)
        {
            Random r = new Random();
            double randomX = r.NextDouble() * boardSize.X;
            r = new Random();
            double randomY = r.NextDouble() * boardSize.Y;
            randomY += 30;
            return new Vector2((float)randomX, (float)randomY);
        }

        public override Vector2 NextStepPosition(Vector2 currentPos, Vector2 targetPos, int stepCount)
        {
            Vector2 desiredMovement = targetPos - currentPos;
            return currentPos + (desiredMovement / stepCount);
        }
    }
}