using Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;


namespace Logic
{
    public abstract class LogicAbstractApi
    {
        public abstract IList CreateBalls(int count);
        public abstract void StartSimulating();
        public abstract void StopSimulating();
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }
        public abstract void ClearBalls();



        public static LogicAbstractApi CreateLogicApi(int width, int height)
        {
            return new LogicApi(width, height);
        }

    }
}
    
