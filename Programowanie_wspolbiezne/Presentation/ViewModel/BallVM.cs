using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
    public class BallVM
    {
        public BallVM(double x, double y)
        {
            Left = x;
            Bottom = y;
        }
        public Double Left { get; set; }
        public Double Bottom { get; set; }
    }
}
