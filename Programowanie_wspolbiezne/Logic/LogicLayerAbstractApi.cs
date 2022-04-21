﻿using System;
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
        public abstract DataLayerAbstractAPI CreateBall();
        public abstract void CreateBallCollection(int quantity);
        public abstract List<DataLayerAbstractAPI> GetBallCollection();
        public abstract Vector2 GetBallPosition();
        public abstract Vector2 NextStepPosition(Vector2 currentPos, Vector2 targetPos, int stepCount);

        public static LogicLayerAbstractApi CreateObjLogic(float X, float Y, DataLayerAbstractAPI data = default(DataLayerAbstractAPI))
        {
            return new BallLogic(X, Y);
        }
    }
}
