using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution060
    {
        public static bool SplitArray(int[] array)
        {
            var ret = false;
            var sum = array.Sum();
            if (sum % 2 == 0)
            { ret = array.EverySubset().Where(k => k.Sum() == sum / 2).Any(); }
            return ret;
        }
    }
}