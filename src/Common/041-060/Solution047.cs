using System;
using System.Linq;

namespace Common
{
    public class Solution047
    {
        public static (int Low, int High) FindBestBuyPriceNaive(int[] prices)
        {
            int length = prices.Length;
            var low = 0;
            var high = 0;
            double ratio = 1;
            for (int i = 0; i < length; i++)
            {
                double x = prices[i];
                for (int j = i + 1; j < length; j++)
                {
                    double y = prices[j];
                    if (y / x > ratio)
                    {
                        low = i;
                        high = j;
                        ratio = y / x;
                    }
                }
            }
            return (low, high);
        }
    }
}