using System;
using System.Linq;

namespace Common
{
    public static class Solution102
    {
        public static int[] ContiguousListSum(int[] list, int k)
        {
            for (int i = 0; i < list.Length; i++)
            {

                for (int j = 0; j + i < list.Length; j++)
                {
                    var enumerable = list.Skip(i).Take(j);
                    if (enumerable.Sum() == k)
                    {
                        return enumerable.ToArray();
                    }
                }
            }
            return null;
        }
    }
}