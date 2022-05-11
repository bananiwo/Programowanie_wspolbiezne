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
        public ObservableCollection<BallVM> CreateBallVMCollection(int quantity)
        {
            BallModelCollection ballModelCollection = new BallModelCollection();

            ballModelCollection.CreateBallsAndInitMovement(quantity);
            List<BallModel> ballCollection = ballModelCollection.GetBallModelCollection();
            ObservableCollection<BallVM> ballVMCollection = new ObservableCollection<BallVM>();
            foreach (BallModel ballM in ballCollection)
            {
                BallVM ballVM = new BallVM(ballM);
                ballVMCollection.Add(ballVM);
            }

            return ballVMCollection;
        }
    }
}
