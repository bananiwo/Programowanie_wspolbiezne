using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
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
            Vector2 startPos = new Vector2(2, 4);
            Vector2 speed = new Vector2(0, 0);
            Vector2 board = new Vector2(750, 750);
            _layer = DataAPI.CreateObject(startPos, speed, board);

            Vector2 pos = _layer.getPosition();
            Assert.AreEqual(pos.X, 2);
            Assert.AreEqual(pos.Y, 4);
        }

        [TestMethod]
        public void TestBallSetValues()
        {
            Vector2 startPos = new Vector2(2, 4);
            Vector2 speed = new Vector2(0, 0);
            Vector2 board = new Vector2(750, 750);
            _layer = DataAPI.CreateObject(startPos, speed, board);

            Vector2 pos = new Vector2(8, 1);
            _layer.setPosition(pos);

            Vector2 pos2 = _layer.getPosition();

            Assert.AreEqual(pos2.X, 8);
            Assert.AreEqual(pos2.Y, 1);
        }

        [TestMethod]
        public void TestBall()
        {
            Vector2 startPos = new Vector2(0, 0);
            Vector2 speed = new Vector2(10, 10);
            Vector2 board = new Vector2(750, 750);
            _layer = DataAPI.CreateObject(startPos, speed, board);

            _layer.step(20);
            Vector2 pos2 = _layer.getPosition();

            Assert.AreEqual(pos2.X, 200);
            Assert.AreEqual(pos2.Y, 200);

            _layer.step(60);
            Vector2 pos3 = _layer.getPosition();

            Assert.AreEqual(pos3.X, 735);
            Assert.AreEqual(pos3.Y, 735);
        }
    }
}