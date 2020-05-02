using System;

namespace Common
{
    public class Solution071
    {
        static System.Random rand = Rand.NewRandom(071);
        public static int rand7() => rand.Next(1, 8);
        public static int rand5()
        {
            var ret = 0;
            for (int i = 0; i < 5; i++)
            {
                ret += rand7();
            }
            ret = ret % 5;
            return ret;
        }
    }
}