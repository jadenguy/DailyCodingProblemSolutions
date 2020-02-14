using System;
using System.Linq;

namespace Common
{
    public static class Solution123
    {
        public enum NumberType
        {
            Scientific, Decimal, Invalid, Integer
        }
        public static bool TryConvertNumeric(string input, out double value)
        {
            const string valid = "0123456789-.";
            var findE = input.ToCharArray().Where(c => c.Equals('e') || c.Equals('E')).Count();
            var numType = findE == 1 ? NumberType.Scientific : findE == 0 ? NumberType.Decimal : NumberType.Invalid;
            value = 0;
            bool ret = input.ToCharArray().All(v => valid.Contains(v));
            switch (numType)
            {
                case NumberType.Decimal:
                    ret &= TryConvertDecimal(input, out value);
                    break;
                case NumberType.Scientific:
                    double mantissa = 0, magnitude = 0;
                    var a = input.LastIndexOf('e');
                    var b = input.LastIndexOf('E');
                    var c = Math.Max(a, b);
                    var d = input.Substring(0, c);
                    var e = input.Substring(c + 1);
                    ret &= TryConvertDecimal(d, out mantissa) && TryConvertDecimal(e, out magnitude);
                    if (ret)
                    { value = mantissa * Math.Pow(10, magnitude); }
                    break;
                default:
                    ret = false;
                    break;
            }
            return ret;
        }
        private static bool TryConvertDecimal(string input, out double value)
        {
            var ret = true;
            value = 0;
            bool isNegative;
            var findNegative = input.ToCharArray().Where(c => c.Equals('-')).Count();
            ret &= (findNegative <= 1);
            if (ret)
            {
                isNegative = (findNegative == 1 && input.FirstOrDefault() == '-');
                ret &= isNegative || findNegative == 0;
            }
            else { return ret; }
            var findDecimal = input.ToCharArray().Where(c => c.Equals('.')).Count();
            ret &= findDecimal <= 1;
            value = isNegative ? -1 : 1;
            return ret;
        }
        public static bool TryConvertNumericBuiltIn(string input, out double value) => double.TryParse(input, out value);
    }
}