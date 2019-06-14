using System;

namespace Common
{
    public static class Solution29
    {
        public static string Encode(string text)
        {
            var ret = string.Empty;
            char letter = text[0];
            int count = 0;
            foreach (var item in text)
            {
                if (item == letter)
                { count++; }
                else { ret += $"{count}{letter}"; count = 1; letter = item; }
            }
            ret += $"{count}{letter}";
            return ret;
        }

        public static string Decode(string encoded)
        {
            throw new NotImplementedException();
        }
    }
}