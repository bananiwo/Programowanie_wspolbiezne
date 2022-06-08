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
            LogicLayer = LogicAbstractApi.CreateLogicApi(width, height);
        }

        public override void StartSimulating()
        {
            LogicLayer.StartSimulating();
        }


        public override void StopSimulating()
        {
            LogicLayer.StopSimulating();
        }

        public override IList Start(int ballVal) => LogicLayer.CreateBalls(ballVal);

        public override void ClearBalls()
        {
            LogicLayer.ClearBalls();
        }
    }
}
