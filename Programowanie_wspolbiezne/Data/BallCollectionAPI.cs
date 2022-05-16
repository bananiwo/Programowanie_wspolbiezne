using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BallCollectionApi
    {
        public abstract Vector2 Board { get; set; }
        public abstract int CountBallApis();
        public abstract int Add(BallApi ball);
        public abstract void Remove(BallApi ball);
        public abstract BallApi GetBallApi(int id);
        public abstract List<BallApi> GetBallApiCollection();

        public static BallApi CreateBall(int id, Vector2 position, Vector2 velocity, double radius)
        {
            return new Ball(id, position, velocity, radius);
        }

        public static double GetRadius(BallApi ball)
        {
            return ball.Radius;
        }

        public static BallCollectionApi CreateBallsApi()
        {
            return new BallCollection();
        }

    }
}
