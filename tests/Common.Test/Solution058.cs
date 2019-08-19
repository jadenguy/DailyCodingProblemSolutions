using System;

namespace Common.Test
{
    public class Solution058
    {
        public static int? FindRotatedSortedArrayIndex(int[] array, int value)
        {
            int? ret = null;
            var direction = value.CompareTo(array[0]);
            for (int i = 0; ret == null && i < array.Length; i++)
            {
                int v = (array.Length + (i * direction)) % array.Length;
                System.Diagnostics.Debug.WriteLine(i);
                System.Diagnostics.Debug.WriteLine(v);
                if (array[v] == value)
                {
                    System.Diagnostics.Debug.WriteLine(v, "solution"); 
                    ret = v;
                }
            }
            return ret;
        }
    }
}