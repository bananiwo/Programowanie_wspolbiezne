using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Data

{
    public interface IBall : INotifyPropertyChanged, ISerializable
    { 
        int ID { get; }
        int Radius { get; }
        Vector2 Velocity { get; set; }
        double X { get; }
        double Y { get; }

        void CreateMovementTask(int interval);
        void StopMovement();

    }
    
}

