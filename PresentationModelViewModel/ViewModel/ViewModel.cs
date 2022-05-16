using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PresentationModelViewModel.ViewModel
{
    public class ViewModel : ViewModelBase
    {
        Model.BallModel BallModel { get; set; }

        public ViewModel()
        {
            BallModel = new Model.BallModel();
            MakeBall = new RelayCommand(BallModel.MakeBall);
            MakeBalls = new RelayCommand(CreateBalls);
            Start = new RelayCommand(StartSimulation);
            Stop = new RelayCommand(StopSimulation);
        }

        public int BallCounter { get => BallModel.BallCounter; set => BallModel.BallCounter = value; }
        public Canvas Canvas { get => BallModel.Canvas; set 
            { 
                BallModel.Canvas = value; 
                RaisePropertyChanged(); 
            } 
        }

        public RelayCommand MakeBalls { protected get; set; }
        public RelayCommand MakeBall { protected get; set; }
        public RelayCommand Start { protected get; set; }
        public RelayCommand Stop { protected get; set; }

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
