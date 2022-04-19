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
        private ObservableCollection<Ball> _items;
        private string _helloString;
        private string _ballQuantityText = "1";
        private int _ballQuantity = 1;

        public ControlsViewModel()
        {
            model = new ControlsModel();
            _helloString = model.ImportantInfo;
            CreateBallsButtonClick = new RelayCommand(() => CreateBallsButtonClickHandler());
            AddBallButtonClick = new RelayCommand(() => AddBallClickHandler());
            RemoveBallButtonClick = new RelayCommand(() => RemoveBallButtonClickHandler());
        }

        public ICommand CreateBallsButtonClick { get; set; }
        public ICommand AddBallButtonClick { get; set; }
        public ICommand RemoveBallButtonClick { get; set; }

        private void CreateBallsButtonClickHandler()
        {
            BallVM ballVM = new BallVM();
            var result = ballVM.CreateBallCollection(_ballQuantity);
            Items = result;
            int c = Items.Count();
            MessageBox.Show("ControlsVM, count=", c.ToString());

        }

        public ObservableCollection<Ball> Items
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
