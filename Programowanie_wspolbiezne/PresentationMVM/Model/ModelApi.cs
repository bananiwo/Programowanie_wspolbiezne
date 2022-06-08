using Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationMVM.Model
{
    internal class ModelApi : ModelAbstractApi
    {
        public override int width { get; }
        public override int height { get; }
        private readonly LogicAbstractApi LogicLayer;

        public ModelApi(int Width, int Height)
        {

            width = Width;
            height = Height;
            LogicLayer = LogicAbstractApi.CreateApi(width, height);
        }

        public override void StartMoving()
        {
            LogicLayer.Start();
        }


        public override void Stop()
        {
            LogicLayer.Stop();
        }

        public override IList Start(int ballVal) => LogicLayer.CreateBalls(ballVal);

        public override void ClearBalls()
        {
            LogicLayer.ClearBalls();
        }
    }
}
