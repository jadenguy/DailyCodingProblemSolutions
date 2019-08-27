using System;

namespace Common
{

    public class UnbalancedCoin
    {
        Random rand;
        int probAnchor;
        public UnbalancedCoin(int seed = 0)
        {
            if (seed == 0) { rand = new Random(); }
            else { rand = new Random(seed); }
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