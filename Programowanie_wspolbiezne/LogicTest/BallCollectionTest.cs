using Logic;
using Data;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTest
{
    [TestClass]
    public class BallCollectionTest
    {
        private LogicLayerAbstractApi _layer;
        [TestMethod]
        public void TestCreateBallCollection()
        {
            _layer = LogicLayerAbstractApi.CreateBallsLogic(740, 740);
            _layer.CreateBallCollection(10);
            Assert.IsTrue(-_layer.GetBallCollection().Count == 10);

        } 
    }
}
