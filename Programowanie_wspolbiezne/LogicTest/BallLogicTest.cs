using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Logic.BallLogic;
using System.Numerics;

namespace LogicTest
{
    [TestClass]
    public class BallLogicTest
    {
        private LogicLayerAbstractApi _layer;
        [TestMethod]
        public void TestCreateBallCollection()
        {
            _layer = LogicLayerAbstractApi.CreateBallsLogic(740, 740);
            _layer.CreateBallCollection(10);
            Assert.AreEqual(_layer.GetBallCollection().Count, 10);
        }

        [TestMethod]
        public void TestBallPosition()
        {
            _layer = LogicLayerAbstractApi.CreateBallsLogic(740, 740);
            Vector2 pos = _layer.GetBallPosition();
            Assert.IsTrue(pos.X <= 740 && pos.X >= 0);
            Assert.IsTrue(pos.Y <= 770 && pos.Y >= 30);
        }
    }
}