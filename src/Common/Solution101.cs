using System.Linq;
using Common.Extensions;
namespace Common
{
    public static class Solution101
    {
        public static (int, int) PrimePairSumTo(int value)
        {
            var ret = (0, 0);
            int[] primes;
            if (value == 4) { ret = (2, 2); }
            else
            {
                primes = SieveOfEratosthenes(value);
                primes.Print();
                var keepLooking = true;
                for (int i = 0; keepLooking && i < primes.Length && (primes[i]) < value / 2; i++)
                {
                    var lower = primes[i];
                    if (primes.Contains(value - lower))
                    {
                        ret = (lower, value - lower);
                        keepLooking = false;
                    }
                }
            }
            return ret;
        }
        private static int[] SieveOfEratosthenes(int maxValue = 10000)
        {
            var range = Enumerable.Range(2, maxValue - 2).ToList();
            for (int i = 0; i < range.Count && range[i] * range[i] <= maxValue; i++)
            {
                var item = range[i];
                System.Diagnostics.Debug.WriteLine(item, "Prime");
                for (int j = item * 2; j < maxValue; j += item)
                {
                    System.Diagnostics.Debug.WriteLine(j, "Removing");
                    range.Remove(j);
                }
            }
            return range.ToArray();
        }
    }
}