using System;

namespace Common
{
    public class Solution14
    {
        public static double CalculatePi(int steps)
        {
            var rand = new Random();
            var inCircleCount = 0;
            for (int i = 0; i < steps; i++)
            {
                var xSquared = Math.Pow(rand.NextDouble(), 2);
                var ySquared = Math.Pow(rand.NextDouble(), 2);
                var sqrt = Math.Sqrt(xSquared + ySquared);
                if (sqrt < 1)
                    inCircleCount++;
            }
            var ret = 4d * inCircleCount / steps;
            return ret;
        }
    }
}