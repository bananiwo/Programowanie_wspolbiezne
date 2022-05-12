using System.Windows.Input;
using PresentationMVM.Model;
using PresentationMVM.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Diagnostics;

namespace PresentationMVM.ViewModel
{
    public class ControlsViewModel : ViewModelBase
    {
        BallModelCollection _ballModel;
        private static ObservableCollection<BallVM> _items;
        private static ControlsViewModel _controller;
        private string _ballQuantityText = "1";
        private int _ballQuantity = 1;

        public ControlsViewModel()
        {
            BallVMCollectionStopMovement();
            _controller = this;
            BallModel = new BallModelCollection();
            CreateBallsButtonClick = new RelayCommand(() => getBallVMCollection());
            AddBallButtonClick = new RelayCommand(() => AddBallClickHandler());
            RemoveBallButtonClick = new RelayCommand(() => RemoveBallButtonClickHandler());
            
        }

        public ICommand CreateBallsButtonClick { get; set; }
        public ICommand AddBallButtonClick { get; set; }
        public ICommand RemoveBallButtonClick { get; set; }

        BallModelCollection _ballModelCollection;

        public ObservableCollection<BallVM> CreateBallVMCollection(int quantity)
        {
            _ballModelCollection = new BallModelCollection();
            _ballModelCollection.CreateBallsAndInitMovement(quantity);
            List<BallModel> ballCollection = _ballModelCollection.GetBallModelCollection();
            ObservableCollection<BallVM> ballVMCollection = new ObservableCollection<BallVM>();
            foreach (BallModel ballM in ballCollection)
            {
                BallVM ballVM = new BallVM(ballM);
                ballVM.X = ballM.Position.X;
                ballVM.Y = ballM.Position.Y;
                ballVMCollection.Add(ballVM);
            }

            return ballVMCollection;
        }


        public void BallVMCollectionMovement()
        {
            _ballModelCollection.BallModelCollectionMovement();
        }
        public void BallVMCollectionStopMovement()
        {
            _ballModelCollection.BallModelCollectionStopMovement();
        }


        private void getBallVMCollection()
        {
            Items = CreateBallVMCollection(BallQuantity);
            BallVMCollectionMovement();

        }


        public ObservableCollection<BallVM> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                RaisePropertyChanged("Items");
            }
        }

        private void AddBallClickHandler()
        {
            if (String.IsNullOrEmpty(BallQuantityText))
            {
                BallQuantity = 1;
            }
            else
            {
                BallQuantity++;
            }

            BallQuantityText = BallQuantity.ToString();
        }

        private void RemoveBallButtonClickHandler()
        {
            if (BallQuantity > 1)
                BallQuantity--;

            BallQuantityText = BallQuantity.ToString();
        }

        public string BallQuantityText
        {
            get
            {
                return _ballQuantityText;
            }
            set
            {
                _ballQuantityText = value;
                BallQuantity = int.Parse(_ballQuantityText);
                RaisePropertyChanged("BallQuantityText");
            }
        }

        public int BallQuantity { get => _ballQuantity; set => _ballQuantity = value; }
        public BallModelCollection BallModel { get => _ballModel; set => _ballModel = value; }
    }
}
