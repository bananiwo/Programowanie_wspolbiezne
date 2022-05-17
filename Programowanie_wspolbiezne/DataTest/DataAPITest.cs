using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using Data;

namespace DataTest
{
    [TestClass]
    public class DataAPITest
    {
        [TestMethod]
        public void TestBallValues()
        {
            BallApi ball = BallCollectionApi.CreateBall(1, new Vector2(1, 1), new Vector2(2, 2), 10);
            Assert.AreEqual(ball.Radius, 10);
            Assert.AreEqual(ball.Position, new Vector2(1, 1));
            Assert.AreEqual(ball.Velocity, new Vector2(2, 2));
            ball.Step(1);
            Assert.AreEqual(ball.Position, new Vector2(3, 3));
        }

        [TestMethod]
        public void TestAddBallToCollectionValues()
        {
            BallCollectionApi balls = BallCollectionApi.CreateBallsApi();
            BallApi ball = BallCollectionApi.CreateBall(1, new Vector2(1, 1), new Vector2(2, 2), 10);
            BallApi ball2 = BallCollectionApi.CreateBall(1, new Vector2(1, 1), new Vector2(2, 2), 15);
            Assert.AreEqual(balls.Add(ball), 0);
            Assert.AreEqual(balls.Add(ball2), 1);
            Assert.AreEqual(balls.CountBallApis(), 2);
        }

        [TestMethod]
        public void TestGetBallFromCollectionValues()
        {
            BallCollectionApi balls = BallCollectionApi.CreateBallsApi();
            BallApi ball = BallCollectionApi.CreateBall(1, new Vector2(1, 1), new Vector2(2, 2), 10);
            BallApi ball2 = BallCollectionApi.CreateBall(1, new Vector2(1, 1), new Vector2(2, 2), 15);
            Assert.AreEqual(balls.Add(ball), 0);
            Assert.AreEqual(balls.Add(ball2), 1);
            Assert.AreEqual(balls.GetBallApi(0), ball);
            Assert.AreEqual(balls.GetBallApi(1), ball2);
        }

        [TestMethod]
        public void TestRemoveBallFromCollectionValues()
        {
            BallCollectionApi balls = BallCollectionApi.CreateBallsApi();
            BallApi ball = BallCollectionApi.CreateBall(1, new Vector2(1, 1), new Vector2(2, 2), 10);
            BallApi ball2 = BallCollectionApi.CreateBall(1, new Vector2(1, 1), new Vector2(2, 2), 15);
            Assert.AreEqual(balls.Add(ball), 0);
            Assert.AreEqual(balls.Add(ball2), 1);
            Assert.AreEqual(balls.CountBallApis(), 2);
            Assert.AreEqual(balls.Remove(ball), true);
            Assert.AreEqual(balls.CountBallApis(), 1);}
}
}