using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class BallCollection : BallCollectionApi
    {
        List<BallApi> _ballApiCollection;
        Vector2 _boardSize;
        internal BallCollection()
        {
            BallApiCollection = new List<BallApi>();
            Board = new Vector2(750, 750);
        }

        public List<BallApi> BallApiCollection { get => _ballApiCollection; set => _ballApiCollection = value; }
        public override Vector2 Board { get => _boardSize; set => _boardSize = value; }
        public override int Add(BallApi ball)
        {
            BallApiCollection.Add(ball);
            return BallApiCollection.Count + 1;
        }

        public override int CountBallApis()
        {
            return BallApiCollection.Count;
        }

        public override BallApi GetBallApi(int id)
        {
            return BallApiCollection[id];
        }

        public override List<BallApi> GetBallApiCollection()
        {
            return BallApiCollection;
        }

        public override void Remove(BallApi ball)
        {
            BallApiCollection.Remove(ball);
        }
    }
}
