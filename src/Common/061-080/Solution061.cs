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