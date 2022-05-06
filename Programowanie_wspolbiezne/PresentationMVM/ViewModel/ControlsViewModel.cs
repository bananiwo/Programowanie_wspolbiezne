using System.Windows.Input;
using PresentationMVM.Model;
using PresentationMVM.ViewModel.Commands;
using System.Collections.ObjectModel;

namespace PresentationMVM.ViewModel
{
    public class ControlsViewModel : ViewModelBase
    {
        BallModel ballModel;
        private ObservableCollection<BallVM> _items;
        private static System.Timers.Timer? _newTargetTimer;
        private static System.Timers.Timer? _newPositionTimer;
        private string _ballQuantityText = "1";
        private int _ballQuantity = 1;

        public ControlsViewModel()
        {
            ballModel = new BallModel();
            CreateBallsButtonClick = new RelayCommand(() => getBallVMCollection());
            AddBallButtonClick = new RelayCommand(() => AddBallClickHandler());
            RemoveBallButtonClick = new RelayCommand(() => RemoveBallButtonClickHandler());
        }

        public ICommand CreateBallsButtonClick { get; set; }
        public ICommand AddBallButtonClick { get; set; }
        public ICommand RemoveBallButtonClick { get; set; }


        private void getBallVMCollection()
        {
            if(_newPositionTimer != null) 
            {
                _newPositionTimer.Stop();
            }
            if (_newTargetTimer != null)
            {
                _newTargetTimer.Stop();
            }
            Items = new ObservableCollection<BallVM>();
            ballModel.CreateBallsAndInitMovement();
            for(int i = 0; i < BallQuantity; i++)
            {
                BallVM ballVM = new BallVM();
                
                Items.Add(new BallVM());

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

        internal ObservableCollection<BallVM> Items { get => _items; set => _items = value; }
        public int BallQuantity { get => _ballQuantity; set => _ballQuantity = value; }
    }
}
