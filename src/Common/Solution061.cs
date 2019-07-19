// Implement integer exponentiation. That is, implement the pow(x, y) function, where x and y are integers and returns x^y.
// Do this faster than the naive method of repeated multiplication.
// For example, pow(2, 10) should return 1024.

namespace Common
{
    public static class Solution061

    {
        public static float power(float x, int y)
        {
            float pow = 1;
            while (y > 0)
            {
                if (y % 2 == 1) { pow *= x; }
                x *= x;
                y /= 2;
            }
            return pow;
        }

    }
}