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
        [DataRow(8, 40320)]
        [DataRow(9, 362880)]
        [DataRow(11, 39916800)]
        [DataRow(12, 479001600)]
        [DataTestMethod]
        public void FactorialWithRecursionMethodShouldSucceed(int n, int result)
        {
            var mathLib = new MathLib(FactorialMethodType.Recursion, FactorialModeType.Standard);

            Assert.IsTrue(mathLib.Factorial(n) == result);
        }

        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(3, 6)]
        [DataRow(5, 120)]
        [DataRow(8, 40320)]
        [DataRow(9, 362880)]
        [DataRow(11, 39916800)]
        [DataRow(12, 479001600)]
        [DataTestMethod]
        public void FactorialWithAggregationMethodShouldSucceed(int n, int result)
        {
            var mathLib = new MathLib(FactorialMethodType.Aggregation, FactorialModeType.Standard);

            Assert.IsTrue(mathLib.Factorial(n) == result);
        }

        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(3, 3)]
        [DataRow(5, 15)]
        [DataRow(8, 105)]
        [DataRow(9, 945)]
        [DataRow(11, 10395)]
        [DataRow(12, 10395)]
        [DataTestMethod]
        public void UnevenFactorialShouldSucceed(int n, long result)
        {
            var mathLib = new MathLib(FactorialMethodType.Aggregation, FactorialModeType.Uneven);

            Assert.IsTrue(mathLib.Factorial(n) == result);
        }

        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(3, 36)]
        [DataRow(5, 14400)]
        [DataRow(8, 1625702400)]
        [DataRow(9, 131681894400)]
        [DataRow(11,1593350922240000 )]
        [DataRow(12, 229442532802560000)]
        [DataTestMethod]
        public void SquareFactorialShouldSucceed(int n, long result)
        {
            var mathLib = new MathLib(FactorialMethodType.Aggregation, FactorialModeType.Square);

            Assert.IsTrue(mathLib.Factorial(n) == result);
        }

    }
}
