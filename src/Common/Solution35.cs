using System;
using System.Linq;

namespace Common
{
    public static class Solution35
    {
        public static char[] SortRGB(char[] array)
        {
            var array2 = array.ToArray();
            int r = 0;
            int i = 0;
            int b = array.GetUpperBound(0);
            int swaps = 0;
            int cycles = 0;
            while (i <= b)
            {
                char letter = array[i];
                System.Diagnostics.Debug.WriteLine(letter);
                if (letter == 'R')
                {
                    System.Diagnostics.Debug.WriteLine(Swap(array, r, ref i, ref swaps));
                    r++;
                }
                else if (letter == 'B')
                {
                    System.Diagnostics.Debug.WriteLine(Swap(array, b, ref i, ref swaps));
                    b--;
                }
                if (letter == 'G')
                {
                    i++;
                    System.Diagnostics.Debug.WriteLine("skip");
                }
                cycles++;
            }
            System.Diagnostics.Debug.WriteLine(cycles, "cycles");
            System.Diagnostics.Debug.WriteLine(swaps, "swaps");
            return array;
        }
        [System.Diagnostics.DebuggerStepThrough]
        private static string Swap(char[] array, int other, ref int index, ref int swaps)
        {
            if (array[other] == array[index])
            {
                index++;
                return "noSwap";
            }
            else
            {
                var temp = array[other];
                array[other] = array[index];
                array[index] = temp;
                swaps++;
                return $"swap {array[other]} at {index} with {temp} at {other}";
            }
        }
    }
}