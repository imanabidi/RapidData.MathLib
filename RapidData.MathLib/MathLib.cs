using System;
using System.Linq;

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

        public long Factorial(int number)
        {
            switch (FactorialMethod)
            {
                case FactorialMethodType.Recursion:
                    return FactorialWithRecursion(number);
                default:
                    return FactorialWithAggregation(number);
            }
        }

        private long FactorialWithRecursion(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return FactorialWithRecursion(number - 1) * number;
        }

        private long FactorialWithAggregation(int number)
        {
            // todo: add guard
            if (number == 0)
            {
                return 1;
            }

            var numbersRange = Enumerable.Range(1, number);
            Func<int, int, int> aggregateFunc;

            switch (FactorialMode)
            {
                case FactorialModeType.Standard:
                    aggregateFunc = (x, y) => x * y;
                    break;

                case FactorialModeType.Uneven:
                    aggregateFunc = (x, y) =>
                    {
                        if (y % 2 == 0)
                        {
                            y = 1;
                        }
                        return x * y;
                    };
                    break;

                case FactorialModeType.Square:
                    aggregateFunc = (x, y) => x * (int)Math.Pow(y, 2);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }


            int aggregatedResult = numbersRange.Aggregate(aggregateFunc); ;
            // uneven
            // in func we check if it is a odd or even number 
            // if even pass 1 and odd usuall number
            return aggregatedResult;
        }


    }
}
