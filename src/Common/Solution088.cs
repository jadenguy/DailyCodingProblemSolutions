namespace Common
{
    public class Solution088
    {
        public static int Divide(int numerator, int denominator)
        {
            var ret = 0;
            while (numerator > denominator)
            {
                ret++;
                numerator -= denominator;
            }
            return ret;
        }
    }
}