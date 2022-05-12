﻿using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallLogicCollection : BallLogicCollectionApi
    {
        BallCollectionApi _data;
        List<BallApi> _ballCollection;
        List<LogicBallApi> _logicBallCollection;
        public BallLogicCollection(BallCollectionApi ballCollection)
        {
            this.Data = ballCollection;
        }
        public override void CreateBallLogicCollection(int quantity)
        {
            Data.CreateBallCollection(quantity);
            BallCollection = Data.GetBallCollection();
            _logicBallCollection = new List<LogicBallApi>();
            foreach (var ball in BallCollection)
            {
                LogicBallApi logicBallApi = LogicBallApi.CreateLogicObject(ball);
                LogicBallCollection.Add(logicBallApi);
            }
        }

        private void CollisionDetection()
        {
            foreach (BallApi ball in _data.GetBallCollection())
            {
                foreach (BallApi otherBall in _data.GetBallCollection())
                {
                    if (ball == otherBall)
                        continue;

                    double distance = Vector2.Distance(ball.GetPosition(), otherBall.GetPosition());
                    if (distance < ball.GetRadius() + otherBall.GetRadius())
                    {
                        ball.SetDirection(Vector2.Multiply(ball.GetDirection(), -1));
                    }
                }
            }
        }

        public override void BallLogicCollectionMovement()
        {
            CollisionDetection();
            Data.BallCollectionMovement();
        }

        public override List<LogicBallApi> GetBallLogicCollection()
        {
            return LogicBallCollection;
        }

        public BallCollectionApi Data { get => _data; set => _data = value; }
        public List<BallApi> BallCollection { get => _ballCollection; set => _ballCollection = value; }
        internal List<LogicBallApi> LogicBallCollection { get => _logicBallCollection; set => _logicBallCollection = value; }
    }
}
