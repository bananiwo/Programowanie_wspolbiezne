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
            BoardSize = new Vector2(750, 750);
        }

        public List<BallApi> BallApiCollection { get => _ballApiCollection; set => _ballApiCollection = value; }
        public Vector2 BoardSize { get => _boardSize; set => _boardSize = value; }

        public override void Add(BallApi ball)
        {
            BallApiCollection.Add(ball);

        }

        public override BallApi GetBallApi(int i)
        {
            return BallApiCollection[i];
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
