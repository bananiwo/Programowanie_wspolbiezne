using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Data

{
    public interface IBall : INotifyPropertyChanged, ISerializable
    { 
        int ID { get; }
        int Radius { get; }
        double X { get; }
        double Y { get; }
        double NewX { get; set; }
        double NewY { get; set; }

        void Move(double time);
        void CreateMovementTask(int interval);

        void Stop();




    }

    
}

