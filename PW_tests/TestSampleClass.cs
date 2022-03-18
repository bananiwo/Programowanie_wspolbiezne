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

        [TestMethod]
        public void testAdd()
        {
            SampleClass cs = new SampleClass();
            int a = 1;  
            int b = 2;
            int result = cs.add(a, b);
            Assert.AreEqual(a+b, result);
            Assert.AreNotEqual(a,result);
            Assert.AreNotEqual(b, result);
        }
    }
}