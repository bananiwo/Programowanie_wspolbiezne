using System.Numerics;

namespace Data
{
    public abstract class BallApi
    {
        public abstract void Step(float interval);
        public abstract void MakeTask(float interval, CancellationToken cancellationToken);

        public event EventHandler<Vector2> PositionChangeOnData;
        protected virtual void OnPositionChangeOnData(Vector2 newPos)
        {
            PositionChangeOnData?.Invoke(this, newPos);
        }

    }
}
