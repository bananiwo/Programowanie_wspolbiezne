using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class BallLogicApi : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPositionChangeOnLogic(BallApi ball, [CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(ball, new PropertyChangedEventArgs(name));
        }

        public int Interval { get; set; }
        public abstract int Add();
        public abstract void Remove(BallApi ball);
        public abstract BallApi GetBall(int id);
        public abstract Vector2 GetPosition(int id);
        public abstract Vector2 GetBoardSize();

        public abstract void StartSimulation();
        public abstract void StopSimulation();
        public abstract bool isSimulating();

        public static BallLogicApi CreateLogic(BallCollectionApi data = default(BallCollectionApi) ){
            return new BallLogic(data ?? BallCollectionApi.CreateBallsApi());
        }

        public static double GetRadius(BallApi ball)
        {
            return BallCollectionApi.GetRadius(ball);
        }
    }
}
