using System;
using System.Linq;

namespace Common
{
    public static class Solution007

    {
        public static int DecodeCount(string code)
        {
            var ret = 1;
            var reverseArray = code.Reverse().Select(x => Convert.ToInt32(x) - 48).ToArray();
            ret += Process(reverseArray, 0);
            return ret;
        }
        private static int Process(int[] reverseArray, int index)
        {
            var ret = 0;
            int length = reverseArray.Length;
            if (index < length)
            {
                if (reverseArray[index] == 0) { ret--; }
                if (index < length - 1)
                {
                    var nextNumber = reverseArray[index + 1];
                    if (nextNumber == 1 || (nextNumber == 2 && reverseArray[index] <= 2))
                    {
                        ret++;
                        ret += Process(reverseArray, index + 2);
                    }
                }
                ret += Process(reverseArray, index + 1);
            }
            return ret;
        }
    }
}