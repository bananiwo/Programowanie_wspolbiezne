using Data;

namespace Logic
{
    public abstract class LogicCollectionApi
    {
        public abstract void CreateBallLogicCollection(int quantity);
        public abstract List<LogicApi> GetBallLogicCollection();
        public static LogicCollectionApi CreateObjCollectionLogic(BallAPI data = default(BallAPI))
        {
            return new BallLogicCollection();
        }

    }
}
