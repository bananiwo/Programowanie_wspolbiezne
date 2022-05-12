using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicBallApi
    {
        public abstract Vector2 Position { get; set; }
        public abstract double Radius { get; }

        public static LogicBallApi CreateLogicObject(BallApi ballApi)
        {
            return new LogicBall(ballApi);
        }

        public event EventHandler<Vector2> PositionChangeOnLogic;
        protected void OnPositionChangeOnLogic(Vector2 newPos)
        {
            PositionChangeOnLogic?.Invoke(this, newPos);
        }


    }
}
