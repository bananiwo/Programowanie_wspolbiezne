using PresentationMVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationMVM.ViewModel
{
    internal class BallVMCollection
    {
        BallModelCollection _ballModelCollection;
        public ObservableCollection<BallVM> CreateBallVMCollection(int quantity)
        {
            _ballModelCollection = new BallModelCollection();

            _ballModelCollection.CreateBallsAndInitMovement(quantity);
            ObservableCollection<BallModel> ballCollection = _ballModelCollection.GetBallModelCollection();
            ObservableCollection<BallVM> ballVMCollection = new ObservableCollection<BallVM>();
            foreach (BallModel ballM in ballCollection)
            {
                BallVM ballVM = new BallVM(ballM);
                ballVMCollection.Add(ballVM);
            }

            return ballVMCollection;
        }

        public void BallVMCollectionMovement()
        {
            _ballModelCollection.BallModelCollectionMovement();
        }
    }
}
