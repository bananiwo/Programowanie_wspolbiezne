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


        public BallCollectionApi Data { get => _data; set => _data = value; }
    }
}
