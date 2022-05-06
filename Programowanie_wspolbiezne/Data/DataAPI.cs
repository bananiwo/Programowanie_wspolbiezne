﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAPI : DataBase

    {
        public abstract double getX();
        public abstract double getY();
        public abstract void setX(double x);
        public abstract void setY(double y);
        public abstract void move();
        public abstract void step(float interval);
        public static DataAPI CreateObject(float X, float Y)
        {
            return new Ball(X, Y);
        }
    }
}
