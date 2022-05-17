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
            _ballApiCollection = new List<BallApi>();
            Board = new Vector2(700, 700);
        }

        public List<BallApi> BallApiCollection { get => _ballApiCollection; }
        public override Vector2 Board { get => _boardSize; set => _boardSize = value; }
        public override int Add(BallApi ball)
        {
            BallApiCollection.Add(ball);
            return BallApiCollection.Count-1;
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

        public override bool Remove(BallApi ball)
        {
            return BallApiCollection.Remove(ball);
        }
    }
}
