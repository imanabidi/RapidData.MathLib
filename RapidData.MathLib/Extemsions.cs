using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using Ardalis.GuardClauses;

namespace RapidData.MathLib
{
    public static class Extensions
    {
        public static BigInteger ParseObjectToBigInteger(object number)
        {
            Guard.Against.Null(number, nameof(number));

            return BigInteger.Parse(number.ToString(), NumberStyles.Any, new CultureInfo("de-DE"));
        }
    }
}
