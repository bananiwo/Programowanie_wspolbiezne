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
        private static System.Timers.Timer? _newTargetTimer;
        private static System.Timers.Timer? _newPositionTimer;
        private string _ballQuantityText = "1";
        private int _ballQuantity = 1;

        public ControlsViewModel()
        {
            _controller = this;
            BallModel = new BallModelCollection();
            CreateBallsButtonClick = new RelayCommand(() => getBallVMCollection());
            AddBallButtonClick = new RelayCommand(() => AddBallClickHandler());
            RemoveBallButtonClick = new RelayCommand(() => RemoveBallButtonClickHandler());
            
        }

        public ICommand CreateBallsButtonClick { get; set; }
        public ICommand AddBallButtonClick { get; set; }
        public ICommand RemoveBallButtonClick { get; set; }


        private void getBallVMCollection()
        {
            BallVMCollection ballVMColl = new BallVMCollection();
            Items = ballVMColl.CreateBallVMCollection(_ballQuantity);
            ballVMColl.BallVMCollectionMovement();

        }

        public static void ChangeBallVMPosition(BallVM ball, Vector2 newPos)
        {
            foreach(var item in _items)
            {
                if(item == ball)
                {
                    Debug.WriteLine("na gorze");
                    Debug.WriteLine(newPos.X);
                    Debug.WriteLine(newPos.Y);
                    item.X = newPos.X;
                    item.Y = newPos.Y;
                }
            }
            
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
