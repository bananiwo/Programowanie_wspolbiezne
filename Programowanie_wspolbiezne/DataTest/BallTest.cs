using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void BallValues()
        {
            Ball ball = new Ball(2, 4);
            Assert.AreEqual(ball.X, 2);
            Assert.AreEqual(ball.Y, 4);
        }

        [TestMethod]
        public void BallSetValues()
        {
            Ball ball = new Ball(0, 0);
            Assert.AreEqual(ball.X, 0);
            ball.X = 10;
            Assert.AreEqual(ball.X, 10);
        }
    }
}