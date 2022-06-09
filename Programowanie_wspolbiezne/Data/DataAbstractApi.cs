using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractApi
    {
        public abstract int Width { get; }
        public abstract int Height { get; }


        public static IBall CreateBall(int ballID, int size, double x, double y, Vector2 velocity)
        {
            return new Ball(ballID, size, x, y, velocity);
        }

        public static DataAbstractApi CreateDataApi(int width, int height)
        {
            return new DataApi(width, height);
        }
    }
}
