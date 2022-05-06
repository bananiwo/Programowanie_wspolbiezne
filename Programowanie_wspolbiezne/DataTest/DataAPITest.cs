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

        [TestMethod]
        public void TestBall()
        {
            _layer = DataAPI.CreateObject(0, 0);
            Assert.AreEqual(_layer.getX(), 0);
            Assert.AreEqual(_layer.getY(), 0);
            _layer.step(20);
            Assert.AreEqual(_layer.getX(), 200);
            Assert.AreEqual(_layer.getY(), 200);
            _layer.step(60);
            Assert.AreEqual(_layer.getX(), 735);
            Assert.AreEqual(_layer.getY(), 735);
        }
    }
}