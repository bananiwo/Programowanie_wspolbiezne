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
        public void TestCreateBallsList()
        {
            api = DataAbstractApi.CreateDataApi(400, 400);
            api.CreateBallsList(5);
            Assert.AreEqual(api.GetBallCounter, 5);
        }

        [TestMethod]
        public void TestClearBalls()
        {
            api = DataAbstractApi.CreateDataApi(400, 400);
            api.CreateBallsList(5);
            Assert.AreEqual(api.GetBallCounter, 5);
            api.ClearBalls();
            Assert.AreEqual(api.GetBallCounter, 0);
        }
    }
}