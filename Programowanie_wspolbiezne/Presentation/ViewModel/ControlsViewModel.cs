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
using System.Timers;

namespace Presentation.ViewModel
{
    internal class ControlsViewModel : ViewModelBase
    {
        BallModel _ballModel;
        private BallLogic _ballLogic;
        private ObservableCollection<BallVM> _items;
        private static Timer _newTargetTimer;
        private static Timer _newPositionTimer;
        private string _ballQuantityText = "1";
        private int _ballQuantity = 1;
        private int _frameRate = 50;

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
            _newTargetTimer = new Timer(1000);
            _newTargetTimer.Elapsed += UpdateBallTargetPositionEvent;
            _newTargetTimer.Start();
        }

        private void InitSmoothMovement()
        {
            _newPositionTimer = new Timer(800/_frameRate);
            _newPositionTimer.Elapsed += BallSmoothMovementEvent;
            _newPositionTimer.Start();
        }

        private void BallSmoothMovementEvent(object? sender, EventArgs e)
        {
           foreach(var item in Items)
            {
                if (item is BallVM)
                {
                    Vector2 currentPos = new Vector2((float)item.XPos, (float)item.YPos);
                    Vector2 a = ((item.NextPosition - currentPos) / _frameRate) + currentPos;
                    item.XPos = a.X;
                    item.YPos = a.Y;
                }
            }
        }

        private void UpdateBallTargetPositionEvent(object? sender, EventArgs e)
        {
            foreach(var item in Items)
            {
                Vector2 targetPos = _ballLogic.GetBallPosition();
                item.NextPosition = targetPos;
            }
        }
    }
}
