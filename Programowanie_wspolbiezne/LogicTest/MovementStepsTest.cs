using Logic;
using Data;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTest
{
    [TestClass]
    public class MovementStepsTest
    {
        LogicLayerAbstractApi _layer;
        Vector2 _firstPos;
        Vector2 _secondPos;
        Vector2 _movementSteps;
        [TestMethod]
        public void TestCalculateMovementSteps()
        {
            _layer = LogicLayerAbstractApi.CreateObjLogic(740, 740);
            _firstPos = new Vector2(20, 35);
            _secondPos = new Vector2(2, 5);
            int stepsCounter = 2;
            _movementSteps = _layer.NextStepPosition(_firstPos, _secondPos, stepsCounter);
            Assert.AreEqual(_movementSteps.X, ((_secondPos.X - _firstPos.X)/stepsCounter) + _firstPos.X);
            Assert.AreEqual(_movementSteps.Y, ((_secondPos.Y - _firstPos.Y)/stepsCounter) + _firstPos.Y);
        }
    }
}
