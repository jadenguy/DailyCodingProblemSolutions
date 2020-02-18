namespace Common
{
    public static class Solution124
    {
        public static int FlipUntilTails(int coins, int seed = 0)
        {
            var ret = 0;
            var rand = (seed == 0) ? new System.Random() : new System.Random(seed);
            for (int i = 1; i < coins; i++)
            {
                do { ret++; }
                while (rand.NextDouble() > 0.5);
            }
            return ret;
        }
    }
}