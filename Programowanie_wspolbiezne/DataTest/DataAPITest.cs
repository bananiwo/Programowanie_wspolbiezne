using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class DataAPITest
    {
        private DataAbstractApi api;

        [TestMethod]
        public void GetWidthTest()
        {
            api = DataAbstractApi.CreateDataApi(400, 400);
            Assert.AreEqual(api.Width, 400);
        }

        [TestMethod]
        public void GetHeightTest()
        {
            api = DataAbstractApi.CreateDataApi(400, 400);
            Assert.AreEqual(api.Height, 400);
        }

        [TestMethod]
        public void TestCreateBall()
        {
            api = DataAbstractApi.CreateDataApi(400, 400);
            IBall ball = DataAbstractApi.CreateBall(1, 2, 10, 15, new System.Numerics.Vector2(5, 11));
            Assert.AreEqual(ball.X, 10);
            Assert.AreEqual(ball.Y, 15);
            Assert.AreEqual(ball.Velocity, new System.Numerics.Vector2(5, 11));
            Assert.AreEqual(ball.ID, 1);
            Assert.AreEqual(ball.Radius, 2);
        }
    }
}