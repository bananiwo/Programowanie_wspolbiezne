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
        public Vector2 Board;
        public abstract void Add(BallApi ball);
        public abstract void Remove(BallApi ball);
        public abstract BallApi GetBallApi(int i);
        public abstract List<BallApi> GetBallApiCollection();

        public static BallApi CreateBall(String uuid, Vector2 position, Vector2 velocity, double radius)
        {
            return new Ball(uuid, position, velocity, radius);
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
