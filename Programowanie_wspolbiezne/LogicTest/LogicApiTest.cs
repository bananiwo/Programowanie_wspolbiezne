using Logic;
using Data;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTest
{
    [TestClass]
    public class LogicTest
    {
        Collisions collisions = new Collisions();
        BallLogicApi ballLogic;
        
        [TestMethod]
        public void CollisionTest()
        {
            ballLogic = BallLogicApi.CreateLogic();
            ballLogic.Add();
            Assert.AreEqual(collisions.DetectCollision(ballLogic.GetBall(0), null), false);
        }

        [TestMethod]
        public void LogicBallTest()
        {
            ballLogic = BallLogicApi.CreateLogic();
            ballLogic.Add();
            Assert.AreEqual(ballLogic.GetBoardSize(), new Vector2(700, 700));
        }

        [TestMethod]
        public void LogicBallTest2()
        {
            ballLogic = BallLogicApi.CreateLogic();
            ballLogic.Add();
            Assert.AreEqual(ballLogic.Count(), 1);
            ballLogic.Remove(ballLogic.GetBall(0));
            Assert.AreEqual(ballLogic.Count(), 0);
        }

        [TestMethod]
        public void LogicBallTest3()
        {
            ballLogic = BallLogicApi.CreateLogic();
            ballLogic.Add();
            ballLogic.Add();
            ballLogic.Add();
            ballLogic.Add();
            Assert.AreEqual(ballLogic.Count(), 4);
            ballLogic.RemoveAll();
            Assert.AreEqual(ballLogic.Count(), 0);
        }

    }
}
