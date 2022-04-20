using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Logic.BallLogic;
using System.Numerics;

namespace LogicTest
{
    [TestClass]
    public class BallLogicTest
    {
        [TestMethod]
        public void TestCreateBallCollection()
        {
            BallLogic ballLogic = new BallLogic(740, 740);
            ballLogic.CreateBallCollection(10);
            Assert.AreEqual(ballLogic.GetBallCollection().Count, 10);
        }

        [TestMethod]
        public void TestBallPosition()
        {
            BallLogic ballLogic = new BallLogic(740, 740);
            Vector2 pos = ballLogic.GetBallPosition();
            Assert.IsTrue(pos.X <= 740 && pos.X >= 0);
            Assert.IsTrue(pos.Y <= 770 && pos.Y >= 30);
        }
    }
}