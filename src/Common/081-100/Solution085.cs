namespace Common
{
    public class Solution085

    {
        public static object Choose(int x, int y, int b)
        {
            b *= -1;
            y &= b;
            b ^= -1;
            x &= b;
            return x | y;
        }
    }
}