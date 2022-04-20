using Logic;
using Data;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTest
{
    [TestClass]
    public class BallCollectionTest
    {
        [TestMethod]
        public void TestCreateBallCollection()
        {
            BallLogic ballLogic = new BallLogic(740, 740);
            ballLogic.CreateBallCollection(10);
            Assert.IsTrue(ballLogic.GetBallCollection().Count == 10);

        } 
    }
}
