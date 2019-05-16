using System;

namespace Common
{
    public class Solution14
    {
        public static double CalculatePi(int steps)
        {
            var rand = new Random();
            var xPoints = new double[steps];
            var yPoints = new double[steps];
            var inCircleCount = 0;
            for (int i = 0; i < steps; i++)
            {
                xPoints[i] = rand.NextDouble() ;
                yPoints[i] = rand.NextDouble() ;
            }
            for (int i = 0; i < steps; i++)
            {
                var xSquared = Math.Pow(xPoints[i],2);
                var ySquared = Math.Pow(yPoints[i],2);
                var sqrt = Math.Sqrt(xSquared + ySquared);
                if (sqrt < 1 ) { inCircleCount++; }
            }
            var ret = 4d * inCircleCount / steps;
            return ret;
        }
    }
}