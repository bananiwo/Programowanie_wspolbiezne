using Data;
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
        ObservableCollection<BallApi> _ballCollection;
        ObservableCollection<LogicBallApi> _logicBallCollection = new ObservableCollection<LogicBallApi>();
        public BallLogicCollection(BallCollectionApi ballCollection)
        {
            this.Data = ballCollection;
        }
        public override void CreateBallLogicCollection(int quantity)
        {
            Data.CreateBallCollection(quantity);
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

        public override ObservableCollection<LogicBallApi> GetBallLogicCollection()
        {
            BallCollection = Data.GetBallCollection();
            foreach(var ball in BallCollection)
            {
                LogicBallApi logicBallApi = LogicBallApi.CreateLogicObject(ball);
                LogicBallCollection.Add(logicBallApi);
            }
            return LogicBallCollection;
        }

        public BallCollectionApi Data { get => _data; set => _data = value; }
        public ObservableCollection<BallApi> BallCollection { get => _ballCollection; set => _ballCollection = value; }
        internal ObservableCollection<LogicBallApi> LogicBallCollection { get => _logicBallCollection; set => _logicBallCollection = value; }
    }
}
