using System;

namespace Common.RandomSelector
{

    public class UnbalancedCoin
    {
        System.Random rand;
        int probAnchor;
        public UnbalancedCoin(int seed = 0)
        {
            rand = Rand.NewRandom(seed);
            probAnchor = rand.Next();
        }
        public bool TossBiased() => rand.Next() < probAnchor;
        public bool TossUnbiased()
        {
            bool a, b;
            int i = 0;
            do
            {
                a = TossBiased();
                b = TossBiased();
                i++;
            } while (a == b);
            System.Diagnostics.Debug.WriteLine(i);
            return a.CompareTo(b) > 0;
        }
    }
}