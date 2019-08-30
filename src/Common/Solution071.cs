// Using a function rand7() that returns an integer from 1 to 7 (inclusive) with uniform probability, implement a function rand5() that returns an integer from 1 to 5 (inclusive).

using System;

namespace Common
{
    public class Solution071
    {
        static Random rand = new Random();
        public static int rand7() => 1 + rand.Next(7);
        public static int rand5()
        {
            var ret = 0;
            for (int i = 0; i < 5; i++)
            {
                ret+=rand7();
            }
            ret = ret % 5;
            return ret;
        }
    }
}