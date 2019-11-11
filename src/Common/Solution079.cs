using System;

namespace Common
{
    public class Solution079
    {
        public static bool ReplaceOneForNonDescending(int[] array)
        {
            int inversions = 0;
            for (int i = 1; i < array.Length; i++)
            {
                var prev = array[i - 1];
                var current = array[i];
                if (prev > current)
                {
                    inversions++;
                    if (current <= 1 
                    || prev >= 1
                    )
                    {
                        return false;
                    }
                }
            }
            return inversions <= 1;
        }
    }
}