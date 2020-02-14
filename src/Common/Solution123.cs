using System;

namespace Common
{
    public static class Solution123
    {
        public static bool TryConvertNumeric(string input, out double value)
        {
            var ret = Double.TryParse(input, out value);
            return ret;
        }
    }
}