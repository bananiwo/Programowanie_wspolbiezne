using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BallCollectionAPI
    {
        public abstract void CreateBallCollection(int quantity);
        public abstract List<BallAPI> GetBallCollection();
        public static BallCollectionAPI CreateObjCollectionLogic()
        {
            return new BallCollection();
        }
    }
}
