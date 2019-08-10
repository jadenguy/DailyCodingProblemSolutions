using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Algorithm;
namespace Common
{
    public class Solution049
    {
        public static int FindLargestContinuousSubset(IEnumerable<int> array) => DnC.DivideAndConquor(array, CombineOrReturnOne);
        public static int CombineOrReturnOne(int a, int b)
        {
            if (a > 0 && b > 0) { return a + b; }
            if (a > 0) { return a; }
            if (b > 0) { return b; }
            return 0;
        }
        
    }
}