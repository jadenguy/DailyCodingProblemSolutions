using System.Linq;

namespace Common
{
    public class Solution060
    {
        public static bool SplitArray(int[] array)
        {
            var ret = false;
            var sorted = array.OrderBy(k => k).ToArray();
            var sum = array.Sum();
            for (int i = 0; i < sorted.Length; i++)
            {
                
            }
            return ret;
        }
    }
}