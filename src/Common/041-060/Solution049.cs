using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Algorithm;
namespace Common
{
    public class Solution049
    {
        public static int FindLargestContinuousSubset(int[] a)
        {
            int length = a.Length;
            int highScore = 0;
            int currentScore = 0;
            var currentBegin = 0;
            var highBegin = 0;
            var highEnd = 0;
            for (int i = 0; i < length; i++)
            {
                currentScore = currentScore + a[i];
                if (highScore < currentScore)
                {
                    highScore = currentScore;
                    highBegin = currentBegin;
                    highEnd = i;
                }
                if (currentScore < 0)
                {
                    currentScore = 0;
                    currentBegin = i + 1;
                }
            }
            System.Diagnostics.Debug.WriteLine("");
            if (highScore > 0)
            {
                System.Diagnostics.Debug.WriteLine(a.Skip(highBegin).Take(highEnd - highBegin + 1).Print(","), "array");
                System.Diagnostics.Debug.WriteLine(a.TakeSub(highBegin, highEnd - highBegin + 1).Sum(), "score");
            }
            else { System.Diagnostics.Debug.WriteLine(0, "array and score"); }
            return highScore;
        }
        public static int Worthless(IEnumerable<int> array) => DnC.DivideAndConquor(array, CombineOrReturnOne);
        public static int CombineOrReturnOne(int a, int b)
        {
            if (a > 0 && b > 0) { return a + b; }
            if (a > 0) { return a; }
            if (b > 0) { return b; }
            return 0;
        }

    }
}