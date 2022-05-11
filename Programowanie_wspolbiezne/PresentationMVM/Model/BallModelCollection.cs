using Logic;
using System.Numerics;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace PresentationMVM.Model
{
    public class BallModelCollection
    {
        private BallLogicCollectionApi _logicLayer;
        ObservableCollection<LogicBallApi> _logicBallColection;
        ObservableCollection<BallModel> _ballModelColection = new ObservableCollection<BallModel>();
        private Vector2 _positionBallModel;
        int _quantity;
        
        public BallModelCollection()
        {
            LogicLayer = BallLogicCollectionApi.CreateObjCollectionLogic();
        }

        public BallLogicCollectionApi LogicLayer { get => _logicLayer; set => _logicLayer = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public ObservableCollection<LogicBallApi> LogicBallColection { get => _logicBallColection; set => _logicBallColection = value; }
        internal ObservableCollection<BallModel> BallModelColection { get => _ballModelColection; set => _ballModelColection = value; }

        internal void CreateBallsAndInitMovement(int quantity=5)
        {
            LogicLayer.CreateBallLogicCollection(quantity);
            LogicBallColection = LogicLayer.GetBallLogicCollection();
            LogicLayer.BallLogicCollectionMovement();
            foreach(var ball in LogicBallColection)
            {
                BallModel ballModel = new BallModel(ball);
                BallModelColection.Add(ballModel);
            }
        }


        public ObservableCollection<BallModel> GetBallModelCollection()
        {
            return BallModelColection;
        }

        


    }
}
