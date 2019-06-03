// Implement integer exponentiation. That is, implement the pow(x, y) function, where x and y are integers and returns x^y.
// Do this faster than the naive method of repeated multiplication.
// For example, pow(2, 10) should return 1024.

namespace Common
{
    public class Solution61
    {
        int runs = 0;
        public float power(float x, int y)
        {
            runs++;
            System.Diagnostics.Debug.WriteLine(runs);

            float temp;

            if (y == 0)
                return 1;
            temp = power(x, y / 2);

            if (y % 2 == 0)
                return temp * temp;
            else
            {
                if (y > 0)
                    return x * temp * temp;
                else
                    return (temp * temp) / x;
            }
        }
    }
}