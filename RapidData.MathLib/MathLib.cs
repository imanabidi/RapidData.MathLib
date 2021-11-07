using System;
using System.Linq;
using System.Numerics;
using Ardalis.GuardClauses;
using RapidData.MathLib.EnumTypes;

namespace RapidData.MathLib
{
    public class MathLib
    {
        public FactorialMethodType FactorialMethod { get; set; }

        public FactorialModeType FactorialMode { get; set; }

        public MathLib(FactorialMethodType factorialMethod, FactorialModeType factorialMode)
        {
            FactorialMethod = factorialMethod;
            FactorialMode = factorialMode;
        }

        public BigInteger Factorial(int number)
        {
            Guard.Against.Negative(number, nameof(number));

            return FactorialMethod switch
            {
                FactorialMethodType.Recursion => FactorialWithRecursion(number),
                FactorialMethodType.Aggregation => FactorialWithAggregation(number),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private BigInteger FactorialWithRecursion(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return FactorialMode switch
            {
                FactorialModeType.Standard => FactorialWithRecursion(number - 1) * number,
                FactorialModeType.Uneven => FactorialWithRecursion(number - 1) * ((number % 2 == 0) ? 1 : number),
                FactorialModeType.Square => FactorialWithRecursion(number - 1) * BigInteger.Pow(number, 2),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private BigInteger FactorialWithAggregation(int number)
        {
            // todo: add guard
            if (number == 0)
            {
                return 1;
            }

            var numbersRange = Enumerable.Range(1, number).Select(i => (BigInteger)i);

            Func<BigInteger, BigInteger, BigInteger> aggregateFunc = FactorialMode switch
            {
                FactorialModeType.Standard => (aggregated, y) => BigInteger.Multiply(aggregated, y),
                FactorialModeType.Uneven => (aggregated, y) => (y % 2 == 0) ? aggregated : aggregated * y,
                FactorialModeType.Square => (aggregated, y) => BigInteger.Multiply(aggregated, BigInteger.Pow(y, 2)),
                _ => throw new ArgumentOutOfRangeException()
            };

            return numbersRange.Aggregate(aggregateFunc);
        }
    }
}
