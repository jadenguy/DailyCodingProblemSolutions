using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution130
    {
        public static int BestProfit(int[] array, int k)
        {
            int length = array.Length;
            var buys = Enumerable.Repeat(true, k + k);
            var sells = Enumerable.Repeat(false, length - k - k);
            var variations = buys.Concat(sells).ToArray().EveryPermutation().ToArray();
            return variations.Max(n => ScoreBuySequence(array, n));
        }
        private static int ScoreBuySequence(int[] array, bool[] n)
        {
            bool buy = true;
            var ret = 0;
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                if (n[i])
                {
                    ret += array[i] * (buy ? -1 : 1);
                    buy = !buy;
                }
            }
            return ret;
        }
    }
}