using Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;


namespace Logic
{
    public abstract class LogicAbstractApi
    {

        public abstract int GetBallCounter { get; }
        public abstract IList CreateBalls(int count);
        public abstract void StartSimulating();
        public abstract void StopSimulating();
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }
        public abstract IBall GetBallAt(int index);
        public abstract bool WallBounce(IBall ball);
        public abstract bool BallBounce(IBall ball);
        public abstract void BallPositionChanged(object sender, PropertyChangedEventArgs args);
        public abstract void ClearBalls();



        public static LogicAbstractApi CreateLogicApi(int width, int height)
        {
            return new LogicApi(width, height);
        }

    }
}
    
