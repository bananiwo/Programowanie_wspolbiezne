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
        public abstract Vector2 GenerateStartPositionInsideBoard();
        public abstract Vector2 GetCurrentBallPosition();
        public abstract void SetCurrentBallPosition(Vector2 newPos);
        public abstract void moveBallLogic();
        public abstract DataAPI GetDataAPI();

        public static LogicApi CreateObjLogic(DataAPI data = default(DataAPI))
        {
            return new BallLogic();
        }
    }
}
