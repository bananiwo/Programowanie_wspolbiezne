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
        public abstract Vector2 Position { get; }
        public abstract double Radius { get; }

        public event EventHandler<Vector2> PositionChangedLogic;
        protected virtual void OnPositionChangedLogic(Vector2 newPosition)
        {
            PositionChangedLogic?.Invoke(this, newPosition);
        }
        public static LogicBallApi CreateLogicObject(BallApi ballApi)
        {
            return new LogicBall(ballApi);
        }


    }
}
