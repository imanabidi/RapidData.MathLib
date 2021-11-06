using System;
using System.Linq;

namespace RapidData.MathLib
{
    public class MathLib
    {
        public int FactorialWithRecursion(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return FactorialWithRecursion(number - 1) * number;
        }

        public int FactorialWithAggregation(int number)
        {
            // todo: add guard
            var numbersRange = Enumerable.Range(1, number);
            var aggregatedResult = numbersRange.Aggregate((x, y) => x * y);

            return aggregatedResult;
        }

    }
}
