using System;
using System.Linq;
using Common.Extensions;

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
                    System.Diagnostics.Debug.WriteLine(array.Swap(r, ref i, ref swaps));
                    r++;
                }
                else if (letter == 'B')
                {
                    System.Diagnostics.Debug.WriteLine(array.Swap(b, ref i, ref swaps));
                    b--;
                }
                else if (letter == 'G')
                {
                    i++;
                    System.Diagnostics.Debug.WriteLine("skip");
                }
                cycles++;
            }
            System.Diagnostics.Debug.WriteLine(cycles, "cycles");
            System.Diagnostics.Debug.WriteLine(swaps, "swaps");
            System.Diagnostics.Debug.WriteLine(array2.Print(), "old");
            System.Diagnostics.Debug.WriteLine(array.Print(), "new");
            return array;
        }
        [System.Diagnostics.DebuggerStepThrough]
        private static string Swap(this char[] array, int other, ref int index, ref int swaps)
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