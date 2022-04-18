using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class BallFactory
    {
        public Ball createBall(double xPos, double yPos)
        {
            return new Ball(xPos, yPos);
        }
    }
}
