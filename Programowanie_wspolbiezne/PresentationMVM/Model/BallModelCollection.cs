using Logic;
using System.Numerics;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace PresentationMVM.Model
{
    public class BallModelCollection
    {
        private BallLogicCollectionApi _logicLayer;
        List<LogicBallApi> _logicBallColection;
        List<BallModel> _ballModelColection;
        int _quantity;
        
        public BallModelCollection()
        {
            BallModelColection = new List<BallModel>();
            LogicLayer = BallLogicCollectionApi.CreateObjCollectionLogic();
        }

        public BallLogicCollectionApi LogicLayer { get => _logicLayer; set => _logicLayer = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public List<LogicBallApi> LogicBallColection { get => _logicBallColection; set => _logicBallColection = value; }
        internal List<BallModel> BallModelColection { get => _ballModelColection; set => _ballModelColection = value; }

        internal void CreateBallsAndInitMovement(int quantity)
        {
            LogicLayer.CreateBallLogicCollection(quantity);
            LogicBallColection = LogicLayer.GetBallLogicCollection();
            foreach(var ball in LogicBallColection)
            {
                BallModel ballModel = new BallModel(ball);
                BallModelColection.Add(ballModel);
            }
            //LogicLayer.BallLogicCollectionMovement();
        }


        public List<BallModel> GetBallModelCollection()
        {
            return BallModelColection;
        }

        public void BallModelCollectionMovement()
        {
            _logicLayer.BallLogicCollectionMovement();
        }




    }
}
