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
        public abstract Vector2 GetPosition();
        public abstract void SetPosition(Vector2 newPos);
        public abstract void moveBallLogic();
        public abstract BallAPI GetDataAPI();

        public static LogicApi CreateObjLogic(BallAPI data = default(BallAPI))
        {
            return new BallLogic();
        }
    }
}
