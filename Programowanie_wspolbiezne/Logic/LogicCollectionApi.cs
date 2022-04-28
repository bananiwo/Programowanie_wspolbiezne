using Data;

namespace Logic
{
    public abstract class LogicCollectionApi
    {
        public abstract void CreateBallCollection(int quantity);
        public abstract List<LogicApi> GetBallCollection();
        public static LogicCollectionApi CreateObjCollectionLogic(DataAPI data = default(DataAPI))
        {
            return new BallLogicCollection();
        }

    }
}
