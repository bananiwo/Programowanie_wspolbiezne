
using Data;
using Logic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PresentationMVM.Model
{
    public class BallModel
    {
        BallLogicApi _ballLogic;
        List<Ellipse> _balls;
        int _ballCounter = 1;
        Canvas _canvas;
        Rectangle _rectangle;

        public BallLogicApi BallLogic { get => _ballLogic; set => _ballLogic = value; }
        public int BallCounter { get => _ballCounter; set => _ballCounter = value; }
        public Canvas Canvas { get => _canvas; set => _canvas = value; }
        public Rectangle Rectangle { get => _rectangle; set => _rectangle = value; }

        public BallModel(BallLogicApi ballLogicApi = null)
        {
            BallLogic = ballLogicApi ?? BallLogicApi.CreateLogic();
            BallLogic.PropertyChanged += UpdateEllipses;
            _balls = new List<Ellipse>();
            Canvas = new Canvas();
            Canvas.Width = BallLogic.GetBoardSize().X;
            Canvas.Height = BallLogic.GetBoardSize().Y;
            Canvas.Background = new SolidColorBrush(Color.FromRgb(95, 158, 160));
        }


        public void MakeBall()
        {
            int id = BallLogic.Add();
            double radius = BallLogicApi.GetRadius(BallLogic.GetBall(id));
            Vector2 pos = BallLogic.GetPosition(id);

            Ellipse ellipse = new Ellipse { Width = radius * 2, Height = radius * 2, Fill = Brushes.Red, StrokeThickness = 1, Stroke = Brushes.Red };
            _balls.Add(ellipse);

            Canvas.SetLeft(ellipse, pos.X);
            Canvas.SetBottom(ellipse, pos.Y);

            Canvas.Children.Add(ellipse);
            if(BallLogic.IsSimulating())
            {
                Stop();
                Start();
            }
        }

        public void MakeBalls()
        {
            _balls.Clear();
            Canvas.Children.Clear();
            BallLogic.RemoveAll();

            for(int i = 0; i < BallCounter; i++)
            {
                MakeBall();
            }
        }

        public void Start()
        {
            BallLogic.StartSimulation();
        }

        public void Stop()
        {
            BallLogic.StopSimulation();
        }

        private void UpdateEllipses(object sender, PropertyChangedEventArgs args)
        {
            BallApi ball = (BallApi)sender;
            Debug.WriteLine("Model");
            Debug.WriteLine(ball.Position);
            Canvas.SetLeft(_balls[ball.Id], ball.Position.X);
            Canvas.SetBottom(_balls[ball.Id], ball.Position.Y);
        }




    }
}
