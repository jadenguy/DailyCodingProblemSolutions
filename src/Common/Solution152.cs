using System;

namespace Common
{
    public class Solution152
    {
        private Random rand = null;

        public Solution152(int seed = 0)
        {
            rand = ((seed == 0) ? new Random() : new Random(seed));
        }

        public T WeightedRandom<T>(T[] objects, double[] probabilities, int seed = 0)
        {
            var length = objects.Length;
            return objects[rand.Next(length)];
        }
    }
}