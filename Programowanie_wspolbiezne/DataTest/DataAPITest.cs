using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class DataAPITest
    {
        DataAPI _layer;
        [TestMethod]
        public void TestBallValues()
        {

            _layer = DataAPI.CreateObject(2, 4);
            Assert.AreEqual(_layer.getX(), 2);
            Assert.AreEqual(_layer.getY(), 4);
        }

        [TestMethod]
        public void TestBallSetValues()
        {
            _layer = DataAPI.CreateObject(0, 0);
            Assert.AreEqual(_layer.getX(), 0);
            _layer.setX(10);
            Assert.AreEqual(_layer.getX(), 10);
        }
    }
}