using Logic;
using Data;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTest
{
    [TestClass]
    public class MovementStepsTest
    {
        [TestMethod]
        public void TestCalculateMovementSteps()
        {
            BallLogic ballLogic = new BallLogic(740, 740);
            Vector2 firstPos = new Vector2(20, 35);
            Vector2 secondPos = new Vector2(2, 5);
            int stepsCounter = 2;
            Vector2 movementSteps = ballLogic.NextStepPosition(firstPos, secondPos, stepsCounter);
            Assert.AreEqual(movementSteps.X, ((secondPos.X - firstPos.X)/stepsCounter) + firstPos.X);
            Assert.AreEqual(movementSteps.Y, ((secondPos.Y - firstPos.Y)/stepsCounter) + firstPos.Y);
        }
    }
}
