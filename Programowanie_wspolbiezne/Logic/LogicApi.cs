using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Numerics;

namespace Logic
{
    public abstract class LogicApi
    {
        public abstract LogicApi CreateBall();
        public abstract void CreateBallCollection(int quantity);
        public abstract List<LogicApi> GetBallCollection();
        public abstract Vector2 GetBallPosition();
        public abstract Vector2 NextStepPosition(Vector2 currentPos, Vector2 targetPos, int stepCount);
        public abstract DataAPI GetDataAPI();

        public static LogicApi CreateObjLogic(float X, float Y, DataAPI data = default(DataAPI))
        {
            return new BallLogic(X, Y);
        }
    }
}
