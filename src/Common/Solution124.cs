using System;
using System.Linq;

namespace Common
{
    public static class Solution124
    {
        public static int FlipIndividualUntilTails(int coins, int seed = 0)
        {
            var ret = 0;
            var coinSet = Enumerable.Range(0, coins).Select(c => new Coin()).ToList();
            for (int i = 1; i < coins; i++)
            {
                do { ret++; }
                while (coinSet[i].Flip());
            }
            return ret;
        }
        public static int FlipGroupUntilTails(int coins)
        {
            var ret = 0;
            var coinSet = Enumerable.Range(0, coins).Select(c => new Coin()).ToList();
            var tailsCoins = coinSet.Where(n => n.HeadsStatus != true);
            while (tailsCoins.Count() > 1)
            {
                ret++;
                foreach (var item in tailsCoins.ToArray())
                {
                    item.Flip();
                }
            }
            return ret;
        }
    }
}