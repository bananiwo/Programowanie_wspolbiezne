using System.Diagnostics;
using System.Numerics;

namespace Data
{
    internal class Ball : BallApi
    {
        private int _id;
        private Vector2 _position;
        private Vector2 _velocity;
        private double _radius;
        private readonly Stopwatch _ballStopwatch = new Stopwatch();
        private Task task;
        public Ball(int id, Vector2 position, Vector2 velocity, double radius)
        {
            Id = id;
            Position = position;   
            Velocity = velocity;
            Radius = radius;
        }

        public override int Id { get => _id; set => _id = value; }
        public override Vector2 Position { get => _position; set => _position = value; }
        public override Vector2 Velocity { get => _velocity; set => _velocity = value; }
        public override double Radius { get => _radius; set => _radius = value; }

        public Stopwatch BallStopwatch => _ballStopwatch;

        public override void Step(float interval)
        {
            Debug.WriteLine("Przed kulka:");
            Debug.WriteLine(Id);
            Debug.WriteLine(Position);
            Position += Vector2.Multiply(Velocity, interval);
            Debug.WriteLine("Po kulka:");
            Debug.WriteLine(Id);
            Debug.WriteLine(Position);
        }

        public override void MakeTask(int interval, CancellationToken cancellationToken)
        {
            task = Movement(interval, cancellationToken);
        }

        private async Task Movement(int interval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                BallStopwatch.Reset();
                BallStopwatch.Start();
                if (!cancellationToken.IsCancellationRequested)
                {
                    Step(interval);
                    OnPropertyChanged();
                }
                BallStopwatch.Stop();

                await Task.Delay((int)(10), cancellationToken);
            }
        }

    }
}
