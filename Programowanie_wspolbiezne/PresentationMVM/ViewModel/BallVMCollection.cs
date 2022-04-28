using System.Collections.ObjectModel;
using PresentationMVM.Model;

namespace PresentationMVM.ViewModel
{
    internal class BallVMCollection
    {

        public ObservableCollection<BallVM> CreateBallVMCollection(int quantity)
        {
            BallModel ballModel = new BallModel();
            ballModel.CreateBallModelCollection(quantity);
            List<BallModel> ballCollection = ballModel.GetBallModelCollection();
            ObservableCollection<BallVM> ballVMCollection = new ObservableCollection<BallVM>();
            foreach (BallModel ballM in ballCollection)
            {
                BallVM ballVM = new BallVM(ballModel);
                ballVM.XPos = ballM.xPosModelBall;
                ballVM.YPos = ballM.yPosModelBall;
                ballVMCollection.Add(ballVM);
            }

            return ballVMCollection;
        }
    }
}
