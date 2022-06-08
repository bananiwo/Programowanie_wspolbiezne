using PresentationMVM.Model;
using System.Collections;
using System.Windows.Input;

namespace PresentationMVM.ViewModel
{

    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ModelAbstractApi ModelLayer;
        private int _BallVal = 1;
        private int width;
        private int height;
        private int size = 0;
        private IList _balls;
        public ICommand AddCommand { get; set; }
        public ICommand RunCommand { get; set; }
        public ICommand StopCommand{ get; set; }
        public ICommand ClearCommand { get; set; }
        public MainWindowViewModel()
        {
            width = 600;
            height = 480;
            ModelLayer = ModelAbstractApi.CreateApi(width, height);
            StopCommand = new RelayCommand(Stop);
            AddCommand = new RelayCommand(AddBalls);
            RunCommand = new RelayCommand(Start);
            ClearCommand = new RelayCommand(ClearBalls);

        }


        public int BallVal
        {
            get
            {

                return _BallVal;
            }
            set
            {

                _BallVal = value;
                RaisePropertyChanged();


            }

        }
        public int Width
        {
            get
            {

                return width;
            }
            set
            {

                width = value;
                RaisePropertyChanged();
            }

        }
        public int Height
        {
            get
            {

                return height;
            }
            set
            {

                height = value;
                RaisePropertyChanged();
            }

        }

        private void ClearBalls()
        {
            ModelLayer.ClearBalls();
        }

        private void AddBalls()
        {
            size += BallVal;
            Balls = ModelLayer.Start(BallVal);
            BallVal = 0;


        }
        private void Stop()
        {
            ModelLayer.Stop();
        }
        private void Start()
        {
            ModelLayer.StartMoving();
        }
        public IList Balls
        {
            get => _balls;
            set
            {
                if (value.Equals(_balls))
                {
                    return;
                }

                _balls = value;
                RaisePropertyChanged();
            }
        }


    }
}
