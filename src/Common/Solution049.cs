namespace Common
{
    public class Solution049
    {
        public static int FindLargestSubstring(int[] array)
        {
            if (array.Length == 0) { return 0; }
            var ret = 0;
            var length = array.Length;
            var writeHead = 0;
            for (int i = 1; i < length; i++)
            {
                int value = array[i];
                if (value >= 0)
                {
                    array[writeHead] += value;
                }
                else
                {
                    writeHead++;
                    array[writeHead] = value;
                    writeHead++;
                    i++;
                }
            }
            if (0 > ret) { return 0; }
            return ret;
        }
    }
}