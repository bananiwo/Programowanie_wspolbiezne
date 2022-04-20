using System;
using System.Collections.Generic;
using System.Windows.Input;
using Presentation.Model;
using Presentation.Commands;
using System.Collections.ObjectModel;
using Data;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows;
using System.Numerics;
using Logic;

namespace Presentation.ViewModel
{
    internal class ControlsViewModel : ViewModelBase
    {
        BallModel _ballModel;
        private BallLogic _ballLogic;
        private ObservableCollection<BallVM> _items;
        private DispatcherTimer _newTargetPostimer = new DispatcherTimer();
        private DispatcherTimer _movementTimer = new DispatcherTimer();
        private string _ballQuantityText = "1";
        private int _ballQuantity = 1;
        private int _frameRate = 30;

        public ControlsViewModel()
        {
            CreateBallsButtonClick = new RelayCommand(() => getBallVMCollection());
            AddBallButtonClick = new RelayCommand(() => AddBallClickHandler());
            RemoveBallButtonClick = new RelayCommand(() => RemoveBallButtonClickHandler());
            _ballLogic = new BallLogic(740, 740);
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
                BallVM ballVM = new BallVM(ball);
                Items.Add(ballVM);
            }
            InitMovement();
            InitSmoothMovement();
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

       private void InitMovement()
        {
            _newTargetPostimer.Tick += UpdateBallTargetPositionEvent;
            _newTargetPostimer.Interval = TimeSpan.FromSeconds(2);
            _newTargetPostimer.Start();
        }

        private void InitSmoothMovement()
        {
            _movementTimer.Tick += BallSmoothMovementEvent;
            _movementTimer.Interval = TimeSpan.FromSeconds(1/100);
            _movementTimer.Start();
        }

        private void BallSmoothMovementEvent(object? sender, EventArgs e)
        {
 
           foreach(var item in Items)
            {
                if (item is BallVM)
                {
                    double x = item.NextStepVector.X;
                    double y = item.NextStepVector.Y;
                    item.Left += 0.1;
                    item.Bottom += y;
                }
            }
        }

        private void UpdateBallTargetPositionEvent(object? sender, EventArgs e)
        {
            foreach(var ballVM in Items)
            {
                Vector2 currentPos = new Vector2((float)ballVM.Left, (float)ballVM.Bottom);
                ballVM.SetNextStepVector(currentPos, _ballLogic.GetBallPosition(), _frameRate);
            }
        }



    }
}
