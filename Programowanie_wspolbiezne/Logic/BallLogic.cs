using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallLogic : BallLogicApi
    {
        BallCollectionApi _ballCollectionApi;
        Collisions _collisions;
        CancellationTokenSource _cancellationTokenSource;
        CancellationToken _cancellationToken;

        public BallCollectionApi BallCollectionApi { get => _ballCollectionApi; set => _ballCollectionApi = value; }
        internal Collisions Collisions { get => _collisions; set => _collisions = value; }
        public CancellationTokenSource CancellationTokenSource { get => _cancellationTokenSource; set => _cancellationTokenSource = value; }
        public CancellationToken CancellationToken { get => _cancellationToken; set => _cancellationToken = value; }

        public BallLogic(BallCollectionApi ballCollectionApi)
        {
            BallCollectionApi = ballCollectionApi;
            Collisions = new Collisions();
            CancellationTokenSource = null;
            Interval = 20;
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Remove(BallApi ball)
        {
            throw new NotImplementedException();
        }

        public override BallApi GetBall(int i)
        {
            throw new NotImplementedException();
        }

        public override void GetPosition(int i)
        {
            return BallCollectionApi.GetBallApi.Position;
        }

        public override Vector2 GetBoardSize()
        {
            return BallCollectionApi.Board;
        }

        public override void StartSimulation()
        {
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;
            foreach(var ball in BallCollectionApi.GetBallApiCollection())
            {
                ball.MakeTask(Interval, CancellationToken);
            }
        }

        public override void StopSimulation()
        {
            if ( CancellationTokenSource != null && ! CancellationTokenSource.IsCancellationRequested)
            {
                CancellationTokenSource.Cancel();
            }
        }
    }
}
