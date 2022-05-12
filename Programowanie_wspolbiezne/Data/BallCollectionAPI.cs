using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BallCollectionApi
    {
        public abstract void CreateBallCollection(int quantity);
        public abstract List<BallApi> GetBallCollection();
        public abstract void BallCollectionMovement();
        public static BallCollectionApi CreateObjCollection()
        {
            return new BallCollection();
        }
    }
}
