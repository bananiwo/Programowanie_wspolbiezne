using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Presentation.Model;
using Presentation.Commands;
using System.Windows;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using Data;

namespace Presentation.ViewModel
{
    internal class ControlsViewModel : ViewModelBase
    {
        ControlsModel model;
        BallModel _ballModel;
        private ObservableCollection<BallVM> _items;
        private string _ballQuantityText = "1";
        private int _ballQuantity = 1;

        public ControlsViewModel()
        {
            CreateBallsButtonClick = new RelayCommand(() => getBallVMCollection());
            AddBallButtonClick = new RelayCommand(() => AddBallClickHandler());
            RemoveBallButtonClick = new RelayCommand(() => RemoveBallButtonClickHandler());
        }

        public ICommand CreateBallsButtonClick { get; set; }
        public ICommand AddBallButtonClick { get; set; }
        public ICommand RemoveBallButtonClick { get; set; }

        private void getBallVMCollection()
        {
            _ballModel = new BallModel(_ballQuantity);
            List<Ball> ballCollection = _ballModel.GetBallCollection();
            Items = new ObservableCollection<BallVM>();
            foreach (Ball ball in ballCollection)
            {
                BallVM ballVM = new BallVM(ball.X, ball.Y);
                Items.Add(ballVM);
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
                _ballQuantity = 1;
            }
            else
            {
                _ballQuantity++;
            }

            BallQuantityText = _ballQuantity.ToString();
        }

        private void RemoveBallButtonClickHandler()
        {
            if (_ballQuantity > 1)
                _ballQuantity--;

            BallQuantityText = _ballQuantity.ToString();
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
                _ballQuantity = int.Parse(_ballQuantityText);
                RaisePropertyChanged("BallQuantityText");
            }
        }
    }
}
