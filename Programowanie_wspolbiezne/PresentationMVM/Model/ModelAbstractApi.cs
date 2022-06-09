using Logic;
using System.Collections;



namespace PresentationMVM.Model
{
    public abstract class ModelAbstractApi
    {
        public abstract int width { get; }
        public abstract int height { get; }
        public abstract void StartSimulating();
        public abstract IList Start(int ballVal);
        public abstract void StopSimulating();
        public abstract void ClearBalls();


        public static ModelAbstractApi CreateApi(int Weight, int Height)
        {
            return new ModelApi(Weight, Height);
        }
    }
}
