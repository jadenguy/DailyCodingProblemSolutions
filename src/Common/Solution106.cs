using System;

namespace Common
{
    public class Solution106
    {
        public static bool CanHop(int[] input)
        {
            int length = input.Length;
            if (length == 1) { return true; }
            bool[] reachable = new bool[length];
            Array.Fill(reachable, false);
            reachable[0] = true;
            for (int i = 0; i < length - 1; i++)
            {
                if (reachable[i])
                {
                    for (int j = 1; j <= input[i] && i + j < length; j++)
                    {
                        reachable[i + j] = true;
                    }
                }
            }
            return reachable[length - 1];
        }
    }
}
