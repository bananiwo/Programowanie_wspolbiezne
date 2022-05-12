using System.Diagnostics;
using System.Numerics;

namespace Data
{
    internal class Ball : BallApi
    {
        private String _uuid;
        private Vector2 _position;
        private Vector2 _velocity;
        private double _radius;
        private readonly Stopwatch _ballStopwatch = new Stopwatch();
        private Task task;
        public Ball(String uuid, Vector2 position, Vector2 velocity, double radius)
        {
            Uuid = uuid;
            Position = position;   
            Velocity = velocity;
            Radius = radius;
        }

        public override string Uuid { get => _uuid; set => _uuid = value; }
        public override Vector2 Position { get => _position; set => _position = value; }
        public override Vector2 Velocity { get => _velocity; set => _velocity = value; }
        public override double Radius { get => _radius; set => _radius = value; }

        public Stopwatch BallStopwatch => _ballStopwatch;

        public override void Step(float interval)
        {
            Position += Vector2.Multiply(Velocity, interval);
        }

        public override void MakeTask(float interval, CancellationToken cancellationToken)
        {
            task = Movement(interval, cancellationToken);
        }

        private async Task Movement(float interval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                BallStopwatch.Reset();
                BallStopwatch.Start();
                if (!cancellationToken.IsCancellationRequested)
                {
                    Step(interval);
                }
                BallStopwatch.Stop();

                await Task.Delay((int)(interval - BallStopwatch.ElapsedMilliseconds), cancellationToken);
            }
        }

    }
}
