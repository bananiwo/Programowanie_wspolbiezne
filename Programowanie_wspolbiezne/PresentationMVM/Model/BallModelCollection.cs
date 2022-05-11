using Logic;
using System.Numerics;
using System.Diagnostics;

namespace PresentationMVM.Model
{
    public class BallModelCollection
    {
        private BallLogicCollectionApi _logicLayer;
        List<LogicBallApi> _logicBallColection;
        List<BallModel> _ballModelColection = new List<BallModel>();
        private Vector2 _positionBallModel;
        int _quantity;
        
        public BallModelCollection()
        {
            LogicLayer = BallLogicCollectionApi.CreateObjCollectionLogic();
        }

        public BallLogicCollectionApi LogicLayer { get => _logicLayer; set => _logicLayer = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public List<LogicBallApi> LogicBallColection { get => _logicBallColection; set => _logicBallColection = value; }
        internal List<BallModel> BallModelColection { get => _ballModelColection; set => _ballModelColection = value; }

        internal void CreateBallsAndInitMovement(int quantity=5)
        {
            LogicLayer.CreateBallLogicCollection(quantity);
            LogicLayer.BallLogicCollectionMovement();
            LogicBallColection = LogicLayer.GetBallLogicCollection();
            foreach(var ball in LogicBallColection)
            {
                BallModel ballModel = new BallModel(ball);
                BallModelColection.Add(ballModel);
            }
        }


        public List<BallModel> GetBallModelCollection()
        {
            return BallModelColection;
        }

        


    }
}
