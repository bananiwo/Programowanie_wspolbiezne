using Logic;
using Data;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

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
            IList list = api.CreateBalls(4);
            Assert.AreEqual(list.Count, 4);
        }

        [TestMethod]
        public void TestClearBalls()
        {
            api = LogicAbstractApi.CreateLogicApi(400, 300);
            IList list = api.CreateBalls(4);
            Assert.AreEqual(list.Count, 4);
            api.ClearBalls();
            Assert.AreEqual(list.Count, 0);
        }
    }
}
