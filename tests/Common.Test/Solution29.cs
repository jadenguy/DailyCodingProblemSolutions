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
            foreach (var candidateLetter in text)
            {
                if (candidateLetter == letter)
                { count++; }
                else { ret += $"{count}{letter}"; count = 1; letter = candidateLetter; }
            }
            ret += $"{count}{letter}";
            return ret;
        }
        public static string Decode(string encoded)
        {
            var ret = string.Empty;
            var i = 1;
            var numStart = 0;
            while (i <= encoded.Length)
            {
                var letter = encoded[i].ToString();
                if (!int.TryParse(letter, out var x))
                {
                    int.TryParse(encoded.Substring(numStart, i - numStart), out var repeat);
                    var range = new String(encoded[i], repeat);
                    ret += range;
                    i++;
                    numStart = i;
                }
                i++;
            }
            return ret;
        }
    }
}