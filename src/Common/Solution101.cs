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
        private static int[] SieveOfEratosthenes(int value = 10000)
        {
            var range = (new int[] { 2 }).Union(Enumerable.Range(3, value - 3)).ToList();
            for (int i = 0; i < range.Count && range[i] * range[i] <= value; i++)
            {
                var item = range[i];
                System.Diagnostics.Debug.WriteLine(item, "Prime");
                for (int j = item * 2; j < value; j += item)
                {
                    System.Diagnostics.Debug.WriteLine(j, "Removing");
                    range.Remove(j);
                }
            }
            return range.ToArray();
        }
    }
}