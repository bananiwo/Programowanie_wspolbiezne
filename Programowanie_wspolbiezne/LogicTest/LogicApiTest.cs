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
    }
}
