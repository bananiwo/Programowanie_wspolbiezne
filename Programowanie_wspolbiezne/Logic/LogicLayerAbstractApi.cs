using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Numerics;

namespace Logic
{
    public abstract class LogicLayerAbstractApi
    {
        public abstract Ball CreateBall();
        public abstract void CreateBallCollection(int quantity);
        public abstract List<Ball> GetBallCollection();
        public abstract Vector2 GetBallPosition();
        public abstract Vector2 NextStepPosition(Vector2 currentPos, Vector2 targetPos, int stepCount);
    }
}
