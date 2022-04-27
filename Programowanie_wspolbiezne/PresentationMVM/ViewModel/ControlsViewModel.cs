﻿using System.Windows.Input;
using PresentationMVM.Model;
using PresentationMVM.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Numerics;
using Logic;

namespace PresentationMVM.ViewModel
{
    public class ControlsViewModel : ViewModelBase
    {
        //MA BRAC TYLKO Z BALLMODEL
        //NI C***A Z NICZEGO WIECEJ!!!!!!!!!!!!!!!!!!!!
        //tu gdzies trzeba dodac budowanie obiektów BallVM albo w ballvm
        BallModel _ballModel;
        BallVM _ballVM;
        //private BallLogic _ballLogic;
        //private LogicApi _logicLayer;


        private ObservableCollection<BallVM> _items;
        private List<BallVM> _ballCollection;
        private static System.Timers.Timer? _newTargetTimer;
        private static System.Timers.Timer? _newPositionTimer;
        private string _ballQuantityText = "1";
        private int _ballQuantity = 1;
        private int _frameRate = 50;

        public ControlsViewModel()
        {
            CreateBallsButtonClick = new RelayCommand(() => getBallVMCollection());
            AddBallButtonClick = new RelayCommand(() => AddBallClickHandler());
            RemoveBallButtonClick = new RelayCommand(() => RemoveBallButtonClickHandler());
            //_logicLayer = LogicApi.CreateObjLogic(740, 740);
            _ballVM = new BallVM();
        }

        public ICommand CreateBallsButtonClick { get; set; }
        public ICommand AddBallButtonClick { get; set; }
        public ICommand RemoveBallButtonClick { get; set; }


        private void createCollection(int quantity)
        {
            _ballCollection = new List<BallVM>();
            for (int i = 0; i < quantity; i++)
            {
                _ballCollection.Add(new BallVM());
            }
        }


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
            _ballModel = new BallModel();
            //List<LogicApi> ballCollection = _ballModel.GetBallCollection();
            Items = new ObservableCollection<BallVM>();
            foreach (BallVM ball in _ballCollection)
            {
                Vector2 randomPosition = ball.GetBallVMPosition();
                ball.XPos = randomPosition.X;
                ball.YPos = randomPosition.Y;
            }
            InitBallTargetPosition();
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

        private void InitBallTargetPosition() // initiates and updates target position to which every Ball moves towards
        {
            // sets initial target position
            foreach (var item in Items)
            {
                Vector2 targetPos = _ballModel.GetBallPosition();
                item.NextPosition = targetPos;
            }
            // updates target position periodically
            _newTargetTimer = new System.Timers.Timer(1000);
            _newTargetTimer.Elapsed += UpdateBallTargetPositionEvent;
            _newTargetTimer.Start();
        }

        private void InitSmoothMovement()
        {
            // updates current ball position every frame
            _newPositionTimer = new System.Timers.Timer(800/_frameRate);
            _newPositionTimer.Elapsed += BallSmoothMovementEvent;
            _newPositionTimer.Start();
        }

        private void BallSmoothMovementEvent(object? sender, EventArgs e) // updates ball position each frame
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

        private void UpdateBallTargetPositionEvent(object? sender, EventArgs e) // sets target position
        {
            foreach(var item in Items)
            {
                Vector2 targetPos = _ballModel.GetBallPosition();
                item.NextPosition = targetPos;
            }
        }
    }
}
