using PresentationMVM.Model;
using System.Collections;
using System.Windows.Input;

namespace PresentationMVM.ViewModel
{

    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ModelAbstractApi ModelLayer;
        private int quantity = 1;
        private int width;
        private int height;
        private int size = 0;
        private IList balls;
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


        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                RaisePropertyChanged();
            }
        }

        public int Width
        {
            get => width;
            set
            {
                width = value;
                RaisePropertyChanged();
            }
        }

        public int Height
        {
            get => height;
            set
            {
                height = value;
                RaisePropertyChanged();
            }
        }

        private void ClearBalls() => ModelLayer.ClearBalls();
        private void Stop() => ModelLayer.StopSimulating();
        private void Start() => ModelLayer.StartSimulating();

        private void AddBalls()
        {
            size += Quantity;
            Balls = ModelLayer.Start(Quantity);
            Quantity = 1;
        }
        
        
        public IList Balls
        {
            get => balls;
            set
            {
                balls = value;
                RaisePropertyChanged();
            }
        }


    }
}
