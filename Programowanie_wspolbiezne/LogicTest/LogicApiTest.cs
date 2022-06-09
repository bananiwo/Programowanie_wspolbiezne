using Logic;
using Data;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTest
{
    [TestClass]
    public class MovementStepsTest
    {
        LogicAbstractApi api;

        [TestMethod]
        public void TestWidthAndHeight()
        {
            api = LogicAbstractApi.CreateLogicApi(400, 300);
            Assert.AreEqual(api.Height, 300);
            Assert.AreEqual(api.Width, 400);
        }

        [TestMethod]
        public void TestCreateBalls()
        {
            api = LogicAbstractApi.CreateLogicApi(400, 300);
            api.CreateBalls(4);
            Assert.AreEqual(api.GetBallCounter, 4);
        }

        [TestMethod]
        public void TestCleareBalls()
        {
            api = LogicAbstractApi.CreateLogicApi(400, 300);
            api.CreateBalls(4);
            Assert.AreEqual(api.GetBallCounter, 4);
            api.ClearBalls();
            Assert.AreEqual(api.GetBallCounter, 0);
        }
    }
}
