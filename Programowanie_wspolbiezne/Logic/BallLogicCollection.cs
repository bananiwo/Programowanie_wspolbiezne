using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallLogicCollection : LogicCollectionApi
    {
        List<LogicApi> _ballCollection;
        public override void CreateBallCollection(int quantity)
        {
            _ballCollection = new List<LogicApi>();
            for (int i = 0; i < quantity; i++)
            {
                BallLogic ball = new BallLogic();
                _ballCollection.Add(ball.CreateBall());
            }
        }

        public override List<LogicApi> GetBallCollection()
        {
            return _ballCollection;
        }
    }
}
