using System;

namespace Common
{
    public class Solution152
    {
        public static object WeightedRandom(object[] objects, double[] probabilities, int seed = 0)
        {
            var rand = (seed == 0) ? new Random() : new Random(seed);
            var length = objects.Length;
            return objects[rand.Next(length)];
        }
    }
}