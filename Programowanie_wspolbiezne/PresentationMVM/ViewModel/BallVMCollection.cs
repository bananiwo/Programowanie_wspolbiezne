using System.Collections.ObjectModel;
using PresentationMVM.Model;

namespace PresentationMVM.ViewModel
{
    internal class BallVMCollection
    {

        public ObservableCollection<BallVM> CreateBallVMCollection(int quantity)
        {
            BallModelCollection ballModelCollection = new BallModelCollection();
            ballModelCollection.CreateBallModelCollection(quantity);
            List<BallModel> ballCollection = ballModelCollection.GetBallModelCollection();
            ObservableCollection<BallVM> ballVMCollection = new ObservableCollection<BallVM>();
            foreach (BallModel ballM in ballCollection)
            {
                BallVM ballVM = new BallVM(ballM);
                ballM.Position = ballM.Position;
                ballVMCollection.Add(ballVM);
            }

            return ballVMCollection;
        }
    }
}
