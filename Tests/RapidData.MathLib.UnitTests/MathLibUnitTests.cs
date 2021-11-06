using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RapidData.MathLib.UnitTests
{
    [TestClass]
    public class MathLibUnitTests
    { 
        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(3, 6)]
        [DataRow(5, 120)]
        [DataRow(11, 39916800)]
        [DataTestMethod]
        public void FactorialWithRecursionShouldSucceed(int n, int result)
        {
            var mathLib = new MathLib(FactorialMode.Recursion);

            Assert.IsTrue(mathLib.Factorial(n) == result);
        }

        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(3, 6)]
        [DataRow(5, 120)]
        [DataRow(11, 39916800)]
        [DataTestMethod]
        public void FactorialWithAggregationShouldSucceed(int n, int result)
        {
            var mathLib = new MathLib(FactorialMode.Aggregation);

            Assert.IsTrue(mathLib.Factorial(n) == result);
        }

    }
}
