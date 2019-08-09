using System.Linq;

namespace Common
{
    public class Solution049
    {
        public static int FindLargestSubstring(int[] array2)
        {
            var array = array2.ToArray();
            if (array.Length == 0) { return 0; }
            var ret = 0;
            var length = array.Length;
            var writeHead = 0;
            for (int i = 1; i < length; i++)
            {
                int value = array[i];
                array[i] = 0;
                if (value >= 0)
                {

                }
                else
                {
                    writeHead += TryWriteAhead(array, length, writeHead, value);

                }
                array[writeHead] += value;
            }
            if (0 > ret) { return 0; }
            return ret;
        }

        private static int TryWriteAhead(int[] array, int length, int index, int value)
        {
            if (index + 1 < length)
            { array[index + 1] = value; }
            return 2;
        }
    }
}