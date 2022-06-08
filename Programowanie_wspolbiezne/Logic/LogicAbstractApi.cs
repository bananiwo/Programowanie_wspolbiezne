using Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;


namespace Logic
{
    public abstract class LogicAbstractApi
    {

        public abstract int GetCount { get; }
        public abstract IList CreateBalls(int count);
        public abstract void Start();
        public abstract void Stop();
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }
        public abstract IBall GetBall(int index);
        public abstract void WallCollision(IBall ball);
        public abstract void BallBounce(IBall ball);
        public abstract void BallPositionChanged(object sender, PropertyChangedEventArgs args);



        public static LogicAbstractApi CreateApi(int width, int height)
        {
            return new LogicApi(width, height);
        }

    }
}
    
