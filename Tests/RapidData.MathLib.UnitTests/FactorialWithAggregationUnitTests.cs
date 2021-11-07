using System.Globalization;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RapidData.MathLib.EnumTypes;

namespace RapidData.MathLib.UnitTests
{
    [TestClass]
    public class FactorialWithAggregationUnitTests
    {
        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(3, 6)]
        [DataRow(5, 120)]
        [DataRow(8, 40320)]
        [DataRow(9, 362880)]
        [DataRow(11, 39916800)]
        [DataRow(12, 479001600)]
        [DataRow(19, 121645100408832000)]
        [DataRow(20, 2432902008176640000)]
        [DataTestMethod]
        public void AggregationFactorial_ShouldSucceed(int n, object expectedResult)
        {
            var mathLib = new MathLib(FactorialMethodType.Aggregation, FactorialModeType.Standard);

            var expectedResultBigInteger = BigInteger.Parse(expectedResult.ToString(), NumberStyles.Any, new CultureInfo("de-DE"));
            var mathLibFactorialResult = mathLib.Factorial(n);
            Assert.IsTrue(mathLibFactorialResult == expectedResultBigInteger);
        }

        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(3, 3)]
        [DataRow(5, 15)]
        [DataRow(8, 105)]
        [DataRow(9, 945)]
        [DataRow(11, 10395)]
        [DataRow(12, 10395)]
        [DataRow(19, 654729075)]
        [DataRow(20, 654729075)]
        [DataTestMethod]
        public void AggregationFactorial_WithUnevenMode_ShouldSucceed(int n, object expectedResult)
        {
            var mathLib = new MathLib(FactorialMethodType.Aggregation, FactorialModeType.Uneven);

            var expectedResultBigInteger = BigInteger.Parse(expectedResult.ToString(), NumberStyles.Any, new CultureInfo("de-DE"));
            var mathLibFactorialResult = mathLib.Factorial(n);
            Assert.IsTrue(mathLibFactorialResult == expectedResultBigInteger);
        }

        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(3, 36)]
        [DataRow(5, 14400)]
        [DataRow(8, 1625702400)]
        [DataRow(9, 131681894400)]
        [DataRow(11, 1593350922240000)]
        [DataRow(12, 229442532802560000)]
        [DataRow(19, "1,4797530453474819213543604224e34")]
        [DataRow(20, "5,9190121813899276854174416896e36")]
        [DataTestMethod]
        public void AggregationFactorial_WithSquareMode_ShouldSucceed(int n, object expectedResult)
        {
            var mathLib = new MathLib(FactorialMethodType.Aggregation, FactorialModeType.Square);

            var expectedResultBigInteger = BigInteger.Parse(expectedResult.ToString(), NumberStyles.Any, new CultureInfo("de-DE"));
            var mathLibFactorialResult = mathLib.Factorial(n);
            Assert.IsTrue(mathLibFactorialResult == expectedResultBigInteger);
        }

    }
}
