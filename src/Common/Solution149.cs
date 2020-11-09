using System;

namespace Common
{
    public class Solution149
    {
        public static object Sum(int[] l, int i, int j)
        {
            var ret = 0;
            for (int x = i; x < j; x++)
            {
                ret += l[x];
            }
            return ret;
        }
    }
}