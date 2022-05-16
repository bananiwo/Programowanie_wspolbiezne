using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PresentationModelViewModel.ViewModel
{
    public class ViewModel : ViewModelBase
    {
        Model.BallModel BallModel { get; set; }
        private string _ballQuantityText;

        public ViewModel()
        {
            BallModel = new Model.BallModel();
            CreateBallsButtonClick = new RelayCommand(() => CreateBalls());
            Start = new RelayCommand(() => StartSimulation());
            Stop = new RelayCommand(() => StopSimulation());
            AddBallButtonClick = new RelayCommand(() => AddBallClickHandler());
            RemoveBallButtonClick = new RelayCommand(() => RemoveBallButtonClickHandler());
            BallQuantityText = BallCounter.ToString();
        }

        public int BallCounter { get => BallModel.BallCounter; set => BallModel.BallCounter = value; }
        public Canvas Canvas { get => BallModel.Canvas; set 
            { 
                BallModel.Canvas = value; 
                RaisePropertyChanged(); 
            } 
        }

        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }
        public RelayCommand CreateBallsButtonClick { get; set; }
        public RelayCommand AddBallButtonClick { get; set; }
        public RelayCommand RemoveBallButtonClick { get; set; }
        public string BallQuantityText
        {
            get
            {
                return _ballQuantityText;
            }
            set
            {
                _ballQuantityText = value;
                BallCounter = int.Parse(_ballQuantityText);
                RaisePropertyChanged("BallQuantityText");
            }
        }

        private void AddBallClickHandler()
        {
            if (String.IsNullOrEmpty(BallQuantityText))
            {
                BallCounter = 1;
            }
            else
            {
                BallCounter++;
            }

            BallQuantityText = BallCounter.ToString();
        }

        private void RemoveBallButtonClickHandler()
        {
            if (BallCounter > 1)
                BallCounter--;

            BallQuantityText = BallCounter.ToString();
        }

        public void SetCanvas(Canvas canvas)
        {
            BallModel.Canvas = canvas;
        }

        public void StartSimulation()
        {
            BallModel.Start();
        }

        public void StopSimulation()
        {
            BallModel.Stop();
        }

        private void CreateBalls()
        {
            BallModel.MakeBalls();
        }
    }
}
