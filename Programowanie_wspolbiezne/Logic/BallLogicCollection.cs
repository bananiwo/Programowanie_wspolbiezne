using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallLogicCollection : BallLogicCollectionApi
    {
        BallCollectionApi _data;
        List<BallApi> _ballCollection;
        List<LogicBallApi> _logicBallCollection = new List<LogicBallApi>();
        public BallLogicCollection(BallCollectionApi ballCollection)
        {
            this.Data = ballCollection;
        }
        public override void CreateBallLogicCollection(int quantity)
        {
            Data.CreateBallCollection(quantity);
        }

        public override void BallLogicCollectionMovement()
        {
            Data.BallCollectionMovement();
        }

        public override List<LogicBallApi> GetBallLogicCollection()
        {
            BallCollection = Data.GetBallCollection();
            foreach(var ball in BallCollection)
            {
                LogicBallApi logicBallApi = LogicBallApi.CreateLogicObject(ball);
                LogicBallCollection.Add(logicBallApi);
            }
            return LogicBallCollection;
        }

        public BallCollectionApi Data { get => _data; set => _data = value; }
        public List<BallApi> BallCollection { get => _ballCollection; set => _ballCollection = value; }
        internal List<LogicBallApi> LogicBallCollection { get => _logicBallCollection; set => _logicBallCollection = value; }
    }
}
