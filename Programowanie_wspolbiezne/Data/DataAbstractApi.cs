using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractApi
    {

        public abstract int GetBallCounter { get; }
        public abstract IList CreateBallsList(int count);
        public abstract void ClearBalls();
        public abstract int Width { get; }
        public abstract int Height { get; }


        public abstract IBall GetBallAt(int index);

        public static DataAbstractApi CreateDataApi(int width, int height)
        {
            return new DataApi(width, height);
        }
    }
}
