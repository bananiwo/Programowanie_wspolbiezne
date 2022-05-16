using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        Mutex _mutex = new Mutex();
        Random _random;
        int counter = 0;

        public BallCollectionApi BallCollectionApi { get => _ballCollectionApi; set => _ballCollectionApi = value; }
        internal Collisions Collisions { get => _collisions; set => _collisions = value; }
        public CancellationTokenSource CancellationTokenSource { get => _cancellationTokenSource; set => _cancellationTokenSource = value; }
        public CancellationToken CancellationToken { get => _cancellationToken; set => _cancellationToken = value; }
        public Mutex Mutex { get => _mutex; set => _mutex = value; }
        public Random Random { get => _random; set => _random = value; }

        public BallLogic(BallCollectionApi ballCollectionApi)
        {
            BallCollectionApi = ballCollectionApi;
            Collisions = new Collisions();
            CancellationTokenSource = null;
            Random = new Random();
            Interval = 20;
        }
        public override bool isSimulating()
        {
            return CancellationTokenSource != null && !CancellationToken.IsCancellationRequested;
        }

        public override int Add()
        {
            BallApi ball;
            Mutex.WaitOne();
            while (true)
            {
                var radius = 15;
                Vector2 startPosition = new Vector2((float)Random.NextDouble() * (BallCollectionApi.Board.X - radius * 2),
                                                    (float)Random.NextDouble() * (BallCollectionApi.Board.Y - radius * 2));

                Vector2 startVelocity = new Vector2((float)(Random.NextDouble() - 0.5) / 2,
                                                    (float)(Random.NextDouble() - 0.5) / 2);
                counter += 1;
                ball = BallCollectionApi.CreateBall(counter, startPosition, startVelocity, radius);
               


                if (BallCollectionApi.GetBallApiCollection().All(u => !Collisions.DetectCollision((BallApi)u, (BallApi)ball))) ;
                {
                    ball.PositionChangeOnData += BallPositionChanged;
                    Mutex.ReleaseMutex();
                    return ball.Id;
                }
            }
            
        }

        void BallPositionChanged(object sender, PropertyChangedEventArgs args)
        {
            BallApi ball = (BallApi)sender;
            Update(ball);
        }

        void Update(BallApi ball)
        {
            Mutex.WaitOne();

            if (ball == null)
            {
                Mutex.ReleaseMutex();
                return;
            }

            Collisions.WallCollision(ball, BallCollectionApi.Board);
            Collisions.BallCollision(BallCollectionApi.GetBallApiCollection(), ball);
            OnPositionChangeOnLogic(ball);
            Mutex.ReleaseMutex();
        }

        public override void Remove(BallApi ball)
        {
            Mutex.WaitOne();
            BallCollectionApi.Remove(ball);
            Mutex.ReleaseMutex();
        }

        public override BallApi GetBall(int id)
        {
            return BallCollectionApi.GetBallApi(id);
        }

        public override Vector2 GetPosition(int id)
        {
            return BallCollectionApi.GetBallApi(id).Position;
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
