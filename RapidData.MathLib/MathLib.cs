using System;
using System.Linq;

namespace RapidData.MathLib
{
    public class MathLib
    { 
        public FactorialMode FactorialMode { get; set; }

        public MathLib(FactorialMode factorialMode)
        {
            FactorialMode = factorialMode;
        }

        public int Factorial(int number)
        {
            switch (FactorialMode)
            {
                case FactorialMode.Recursion:
                    return FactorialWithRecursion(number);
                default:
                    return FactorialWithAggregation(number);
            }
        }

        private int FactorialWithRecursion(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return FactorialWithRecursion(number - 1) * number;
        }

        private int FactorialWithAggregation(int number)
        {
            if (number == 0)
            {
                return 1;
            }


            // todo: add guard
            var numbersRange = Enumerable.Range(1, number);
            var aggregatedResult = numbersRange.Aggregate((x, y) => x * y);

            return aggregatedResult;
        }

    }
}
