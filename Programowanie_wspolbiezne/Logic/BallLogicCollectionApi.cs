using Data;
using System.Collections.ObjectModel;

namespace Logic
{
    public abstract class BallLogicCollectionApi
    {
        
        public static BallLogicCollectionApi CreateObjCollectionLogic(BallCollectionApi data = default(BallCollectionApi))
        {
            data ??= BallCollectionApi.CreateObjCollection();
            return new BallLogicCollection(data);
        }
        public abstract void CreateBallLogicCollection(int quantity);
        public abstract void BallLogicCollectionMovement();
        public abstract List<LogicBallApi> GetBallLogicCollection();
    }
}
