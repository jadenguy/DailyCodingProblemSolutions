using System;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public class Solution14
    {


        public static double CalculatePi(int steps, int parallel = 1)
        {
            var rand = new Random();
            var seeds = new int[parallel];
            for (int i = 0; i < seeds.Length; i++)
            {
                seeds[i] = rand.Next();
            }
            var inCircleCount = new int[parallel];
            Parallel.For(0, parallel, (a, b) =>
                    {
                        var randP = new Random(seeds[a]);
                        for (int i = 0; i < steps; i++)
                        {
                            var xSquared = Math.Pow(randP.NextDouble(), 2);
                            var ySquared = Math.Pow(randP.NextDouble(), 2);
                            var sqrt = Math.Sqrt(xSquared + ySquared);
                            if (sqrt < 1)
                                inCircleCount[a]++;
                        }
                    });
            var sum = inCircleCount.Sum();
            var ret = (4d * sum) / (steps * parallel);
            return ret;
        }
    }
}