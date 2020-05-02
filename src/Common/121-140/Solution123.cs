using System;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution123
    {
        enum NumberType
        {
            Scientific, Decimal, Invalid, Integer
        }
        public static bool TryConvertNumeric(string input, out double value)
        {
            const string valid = "0123456789Ee-.";
            const string validNumbers = "0123456789";
            var findE = input.ToCharArray().Where(c => c.Equals('e') || c.Equals('E')).Count();
            var numType = findE == 1 ? NumberType.Scientific : findE == 0 ? NumberType.Decimal : NumberType.Invalid;
            value = 0;
            bool ret = input.ToCharArray().All(v => valid.Contains(v));
            ret &= input.Any(n => validNumbers.Contains(n));
            if (!ret) { return false; }
            numType.WriteHost();
            switch (numType)
            {
                case NumberType.Decimal:
                    ret &= TryConvertDecimal(input, out value);
                    break;
                case NumberType.Scientific:
                    double mantissa = 0, magnitude = 0;
                    var divider = Math.Max(input.LastIndexOf('e'), input.LastIndexOf('E'));
                    var pMantissa = input.Substring(0, divider);
                    var pMagnitude = input.Substring(divider + 1);
                    ret &= pMantissa.Length > 0 && pMagnitude.Length > 0;
                    ret &= TryConvertDecimal(pMantissa, out mantissa) && TryConvertInteger(pMagnitude, out magnitude);
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
            if (!ret) { return ret; }
            ret = IsNegative(input, out var isNegative);
            if (!ret) { return ret; }
            if (isNegative) { input = input.Substring(1); }
            ret = FindDecimal(input, isNegative, out var decimalPlace);
            if (!ret) { return ret; }
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '.')
                {
                    var current = input[i] - 48;
                    var magnitude = decimalPlace - i - ((decimalPlace > i) ? 1 : 0);
                    var v = Math.Pow(10, magnitude);
                    (v * current).WriteHost();
                    value += v * current;
                }
            }
            value *= isNegative ? -1 : 1;
            return ret;
        }
        private static bool TryConvertInteger(string input, out double value)
        {
            value = 0;
            FindDecimal(input, true, out var decimalPlace);
            return decimalPlace == input.Length ? TryConvertDecimal(input, out value) : false;
        }
        private static bool IsNegative(string input, out bool isNegative)
        {
            var ret = true;
            isNegative = false;
            var findNegative = input.ToCharArray().Where(c => c.Equals('-')).Count();
            ret &= (findNegative <= 1);
            if (!ret) { return ret; }
            isNegative = (findNegative == 1 && input.FirstOrDefault() == '-');
            ret &= isNegative || findNegative == 0;
            return ret;
        }
        private static bool FindDecimal(string input, bool isNegative, out int decimalPlace)
        {
            var ret = true;
            var findDecimal = input.ToCharArray().Where(c => c.Equals('.')).Count();
            ret &= findDecimal <= 1;
            decimalPlace = input.Length;
            for (int i = 0; i < input.Length; i++)
            {
                var current = input[i];
                if (current == '.')
                {
                    decimalPlace = i;
                    break;
                }
            }
            return ret;
        }
        public static bool TryConvertNumericBuiltIn(string input, out double value) => double.TryParse(input, out value);
    }
}