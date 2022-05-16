using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Data
{
    public abstract class BallApi : INotifyPropertyChanged
    {
        public abstract void Step(float interval);
        public abstract double Radius { get; set; }
        public abstract Vector2 Position { get; set; }
        public abstract Vector2 Velocity { get; set; }
        public abstract int Id { get; set; }
        public abstract void MakeTask(float interval, CancellationToken cancellationToken);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
