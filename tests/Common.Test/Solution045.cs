using System;

namespace Common
{
    public class Solution045
    {
        public static int Rand5() => (new Random()).Next(1, 5);

        internal static object Rand7()
        {
            throw new NotImplementedException();
        }
    }
}