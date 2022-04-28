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
        //public abstract void CreateBallCollection(int quantity);
        //public abstract List<LogicApi> GetBallCollection();
        public abstract Vector2 GeneratePositionInsideBoard();
        public abstract Vector2 GetCurrentBallPosition();
        public abstract void SetCurrentBallPositionX(double XPos);
        public abstract void SetCurrentBallPositionY(double YPos);
        public abstract Vector2 NextStepPosition(Vector2 currentPos, Vector2 targetPos, int stepCount);
        public abstract DataAPI GetDataAPI();

        public static LogicApi CreateObjLogic(DataAPI data = default(DataAPI))
        {
            return new BallLogic();
        }
    }
}
