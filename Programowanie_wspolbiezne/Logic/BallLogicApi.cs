using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class BallLogicApi
    {
        public event EventHandler<Vector2> PositionChangeOnLogic;
        protected virtual void OnPositionChangeOnLogic(Vector2 newPos)
        {
            PositionChangeOnLogic?.Invoke(this, newPos);
        }

        public int Interval { get; set; }
        public abstract void Add();
        public abstract void Remove(BallApi ball);
        public abstract BallApi GetBall(int i);
        public abstract void GetPosition(int i);
        public abstract Vector2 GetBoardSize();

        public abstract void StartSimulation();
        public abstract void StopSimulation();

        public static BallLogicApi CreateLogic(BallCollectionApi data = default(BallCollectionApi) {
            return new BallLogic(data ?? BallCollectionApi.CreateBallsApi());
        }

        public static double GetRadius(BallApi ball)
        {
            return BallCollectionApi.GetRadius(ball);
        }
    }
}
