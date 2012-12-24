using System;
using Calculator.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public  void Test1()
        {
            Complecs val1 = new Complecs("1+2j");
            Complecs val2 = new Complecs("4+3j");
            val1.Add(val2).Add(val2);
            Assert.IsTrue(val1.ToString()=="9+8j");
        }
        [TestMethod]
        public void RealTest()
        {
            Real<double> test = new Real<double>(2);
            test.Add(new Real<double>(3)).Multiply(new Real<double>(4));
            Assert.IsTrue(test.valuereal == 20);
        }
        
    }
}
