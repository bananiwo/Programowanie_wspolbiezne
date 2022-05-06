using Logic;
using System.Numerics;
using System.Diagnostics;

namespace PresentationMVM.Model
{
    public class BallModelCollection
    {
        private BallLogicCollectionApi _logicLayer;
        private Vector2 _positionBallModel;
        int _quantity;
        
        public BallModelCollection()
        {
            Quantity = 5;
            LogicLayer = BallLogicCollectionApi.CreateObjCollectionLogic();
        }

        public BallLogicCollectionApi LogicLayer { get => _logicLayer; set => _logicLayer = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }

        public void CreateBallsAndInitMovement()
        {
            LogicLayer.CreateBallLogicCollection(Quantity);
            LogicLayer.BallLogicCollectionMovement();
        }

        


    }
}
