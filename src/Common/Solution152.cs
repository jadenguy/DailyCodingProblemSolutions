using System;
using System.Linq;

namespace Common
{
    public class Solution152
    {
        private Random rand = null;

        public Solution152(int seed = 0)
        {
            rand = ((seed == 0) ? new Random() : new Random(seed));
        }

        public T WeightedRandom<T>(T[] objects, double[] probabilities)
        {
            var runningProbability = probabilities.ToArray();
            for (int i = 1; i < runningProbability.Length; i++)
            {
                runningProbability[i] += runningProbability[i - 1];
            }
            var v = rand.NextDouble();
            return objects[runningProbability.Where(p => p < v).Count()];
        }
    }
}