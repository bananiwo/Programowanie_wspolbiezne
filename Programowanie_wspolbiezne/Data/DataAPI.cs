using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading;

namespace Data
{
    internal class DataApi : DataAbstractApi
    {
        public override int Width { get; }
        public override int Height { get; }



        public DataApi(int width, int height)
        {
            Width = width;
            Height = height;

        }

    }
}
