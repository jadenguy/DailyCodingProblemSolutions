using System;
using System.Collections.Generic;
using Common.Regex;

namespace Common
{
    public static partial class Solution31
    {
        public static int MeasureDistance(string textA, string textB)
        {
            var ret = Math.Max(textA.Length, textB.Length);
            var matchList = new List<SubString>();
            foreach (var subA in textA.AllSubStrings())
            {
                foreach (var subB in textB.AllSubStrings())
                {
                    if (subA.Text == subB.Text)
                    {
                        matchList.Add(subB);
                    }
                }
            }
            return ret;
        }
        private static IEnumerable<SubString> AllSubStrings(this string textA)
        {
            for (int start = 0; start <= textA.Length; start++)
            {
                for (int length = 1; length <= textA.Length - start; length++)
                {
                    var subString = textA.Substring(start, length);
                    yield return new SubString(subString, start, length);
                }
            }
        }
    }
}