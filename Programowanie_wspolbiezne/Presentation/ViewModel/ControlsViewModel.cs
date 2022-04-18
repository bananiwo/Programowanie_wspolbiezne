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

namespace Presentation.ViewModel
{
    internal class ControlsViewModel : ViewModelBase
    {
        ControlsModel model;
        public ObservableCollection<BallVM> Items { get; set; }
        private string _helloString;
        private string _ballQuantityText;

        public ControlsViewModel()
        {
            Items = new ObservableCollection<BallVM>
            {
                new BallVM(100, 100),
                new BallVM(250, 250),
                new BallVM(582, 250)
            };

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
            MessageBox.Show("Create balls");
        }

        private void AddBallClickHandler()
        {
            int ballQuantity;
            if (String.IsNullOrEmpty(BallQuantityText))
            {
                ballQuantity = 1;
            }
            else
            {
                ballQuantity = int.Parse(BallQuantityText);
                ballQuantity++;
            }

            BallQuantityText = ballQuantity.ToString();
        }

        private void RemoveBallButtonClickHandler()
        {
            int ballQuantity;

            ballQuantity = int.Parse(BallQuantityText);
            if (ballQuantity > 1)
                ballQuantity--;

            BallQuantityText = ballQuantity.ToString();
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
                RaisePropertyChanged("BallQuantityText");
            }
        }

        public string HelloString
        {
            get
            {
                return model.ImportantInfo;
            }
            set
            {
                _helloString = value;
                RaisePropertyChanged("HelloString");
            }
        }
    }
}
