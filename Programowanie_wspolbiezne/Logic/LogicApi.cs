using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class LogicApi : LogicAbstractApi
    {
        private readonly DataAbstractApi dataLayer;
        private readonly Mutex mutex = new Mutex();
        private readonly int error = 10;
        private Collisions collisions = new Collisions();

        public LogicApi(int width, int height)
        {
            dataLayer = DataAbstractApi.CreateDataApi(width, height);
            Width = width;
            Height = height;

        }

        public override int Width { get; set; }
        public override int Height { get; set; }

        public override void StartSimulating()
        {
            for (int i = 0; i < dataLayer.GetBallCounter; i++)
            {
                dataLayer.GetBallAt(i).CreateMovementTask(30);
            }
        }

        public override void StopSimulating()
        {
            for (int i = 0; i < dataLayer.GetBallCounter; i++)
            {
                dataLayer.GetBallAt(i).StopMovement();

            }
        }


        public override IList CreateBalls(int count)
        {
            int previousCount = dataLayer.GetBallCounter;
            IList temp = dataLayer.CreateBallsList(count);
            for (int i = 0; i < dataLayer.GetBallCounter - previousCount; i++)
            {
                dataLayer.GetBallAt(previousCount + i).PropertyChanged += BallPositionChanged;
            }
            return temp;
        }

        public override void ClearBalls() => dataLayer.ClearBalls();

        private IBall GetBallAt(int index) => dataLayer.GetBallAt(index);


        private int GetBallCounter { get => dataLayer.GetBallCounter; }

        private void BallPositionChanged(object sender, PropertyChangedEventArgs args)
        {
            IBall ball = (IBall)sender;
            mutex.WaitOne();
            Collisions.WallBounce(ball, Width, Height, error);
            Collisions.BallBounce(ball, dataLayer.Balls);
            mutex.ReleaseMutex();
        }


    }
}
