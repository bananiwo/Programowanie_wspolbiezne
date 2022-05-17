using Data;
using System.ComponentModel;
using System.Numerics;

namespace Logic
{
    internal class BallLogic : BallLogicApi
    {
        BallCollectionApi _ballApis;
        Collisions _collisions;
        CancellationTokenSource _cancellationTokenSource;
        CancellationToken _cancellationToken;
        Mutex _mutex = new Mutex();
        Random _random;

        public BallCollectionApi BallApis { get => _ballApis; set => _ballApis = value; }
        internal Collisions Collisions { get => _collisions; set => _collisions = value; }
        public CancellationTokenSource CancellationTokenSource { get => _cancellationTokenSource; set => _cancellationTokenSource = value; }
        public CancellationToken CancellationToken { get => _cancellationToken; set => _cancellationToken = value; }
        public Mutex Mutex { get => _mutex; set => _mutex = value; }
        public Random Random { get => _random; set => _random = value; }

        public BallLogic(BallCollectionApi ballCollectionApi)
        {
            BallApis = ballCollectionApi;
            Collisions = new Collisions();
            CancellationTokenSource = null;
            Random = new Random();
            Interval = 20;
        }
        public override bool IsSimulating()
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
                Vector2 startPosition = new Vector2((float)Random.NextDouble() * (BallApis.Board.X - radius * 2),
                                                    (float)Random.NextDouble() * (BallApis.Board.Y - radius * 2));

                Vector2 startVelocity = new Vector2((float)(Random.NextDouble() - 0.5) / 2,
                                                    (float)(Random.NextDouble() - 0.5) / 2);
                
                ball = BallCollectionApi.CreateBall(BallApis.CountBallApis(), startPosition, startVelocity, radius);

                if (BallApis.GetBallApiCollection().All(u => !Collisions.DetectCollision((BallApi)u, (BallApi)ball))) ;
                {
                    var result = BallApis.Add(ball);
                    ball.PropertyChanged += BallPositionChanged;
                    Mutex.ReleaseMutex();
                    return result;
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

            Collisions.WallCollision(ball, BallApis.Board);
            Collisions.BallCollision(BallApis.GetBallApiCollection(), ball);
            OnPropertyChanged(ball);
            Mutex.ReleaseMutex();
        }

        public override void Remove(BallApi ball)
        {
            Mutex.WaitOne();
            BallApis.Remove(ball);
            Mutex.ReleaseMutex();
        }

        public override void RemoveAll()
        {
            BallApis.GetBallApiCollection().Clear();
        }

        public override BallApi GetBall(int id)
        {
            return BallApis.GetBallApi(id);
        }

        public override Vector2 GetPosition(int id)
        {
            return BallApis.GetBallApi(id).Position;
        }

        public override Vector2 GetBoardSize()
        {
            return BallApis.Board;
        }

        public override void StartSimulation()
        {
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;
            foreach(var ball in BallApis.GetBallApiCollection())
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

        public override int Count()
        {
            return BallApis.CountBallApis();
        }
    }
}
