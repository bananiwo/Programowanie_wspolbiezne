using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallLogicCollection : LogicCollectionApi
    {
        List<LogicApi> _ballLogicCollection;
        private BallAPI _dataLayer;
        private BallCollectionAPI _dataCollection;
        public override void CreateBallLogicCollection(int quantity)
        {
            _dataLayer = BallAPI.CreateObject();
            _dataCollection = BallCollectionAPI.CreateObjCollectionLogic();
            _dataCollection.CreateBallCollection(quantity);
            List<BallAPI> ballCollection = _dataCollection.GetBallCollection();
            _ballLogicCollection = new List<LogicApi>();
            foreach (BallAPI api in ballCollection)
            {
                BallLogic ballLogic = new BallLogic();
                _ballLogicCollection.Add(ballLogic);
                ballLogic.SetPosition(_dataLayer.getPosition());
            }
        }

        public override List<LogicApi> GetBallLogicCollection()
        {
            return _ballLogicCollection;
        }
    }
}
