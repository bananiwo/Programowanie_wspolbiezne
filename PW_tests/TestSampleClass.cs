using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PW_tests
{
    [TestClass]
    public class TestSampleClass
    {
        [TestMethod]
        public void testMultiplication()
        {
            SampleClass cs = new SampleClass();
            int value = 3;
            int result = cs.multiplicate(value);
            Assert.AreEqual(value * 10, result);
        }
    }
}