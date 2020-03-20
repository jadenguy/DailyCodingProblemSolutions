using System;

namespace Common.Test
{
    public class Solution062
    {
        public static int[][] Pascal(int arraySize)
        {
            var ret = new int[arraySize][];
            if (arraySize > 0) { ret[0] = new int[] { 1 }; }
            for (int i = 1; i < arraySize; i++)
            {
                var lastRow = ret[i - 1];
                ret[i] = new int[i + 1];
                var row = ret[i];
                row[0] = 1;
                row[i] = 1;
                for (int j = 1; j < i; j++)
                {
                    int upperLeft = lastRow[j - 1];
                    int upperRight = lastRow[j];
                    row[j] = upperLeft + upperRight;
                }
            }
            return ret;
        }
        public static int[,] As2DArray(int arraySize)
        {
            var ret = new int[arraySize, arraySize];
            if (arraySize > 0)
            {
                ret[0, 0] = 1;
                for (int i = 0; i < arraySize; i++)
                {
                    for (int j = 0; j < arraySize; j++)
                    {
                        int left, above;
                        if (i == 0) { above = 0; } else { above = ret[i - 1, j]; }
                        if (j == 0) { left = 0; } else { left = ret[i, j - 1]; }
                        ret[i, j] += above;
                        ret[i, j] += left;
                    }
                }
            }
            for (int i = 0; i < arraySize; i++)
            {
                System.Diagnostics.Debug.WriteLine("");
                for (int j = 0; j < arraySize; j++)
                {
                    System.Diagnostics.Debug.Write(ret[i, j]);
                    System.Diagnostics.Debug.Write(",");
                }
            }
            return ret;
        }
    }
}