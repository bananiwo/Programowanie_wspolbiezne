using System.Numerics;

namespace Data
{
    public abstract class BallApi
    {
        public abstract void Step(float interval);
        public abstract double Radius { get; set; }
        public abstract Vector2 Position { get; set; }
        public abstract Vector2 Velocity { get; set; }
        public abstract string Uuid { get; set; }
        public abstract void MakeTask(float interval, CancellationToken cancellationToken);

        public event EventHandler<Vector2> PositionChangeOnData;
        protected virtual void OnPositionChangeOnData(Vector2 newPos)
        {
            PositionChangeOnData?.Invoke(this, newPos);
        }

    }
}
