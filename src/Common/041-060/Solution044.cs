using System;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution044
    {
        public static int NaiveInversionCount(int[] a)
        {
            var ret = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j]) { ret++; }
                }
            }
            return ret;
        }
        public static T[] CountSorts<T>(T[] array, ref int swaps) where T : IComparable<T>
        {
            var newArray = array.MergeSortMeasure(ref swaps).ToArray();
            return newArray;
        }
        // private static IEnumerable<IEnumerable<T>> ChopArray<T>(IEnumerable<T> array)
        // {
        //     int length = array.Count();
        //     var leftHalf = array.Take(length / 2);
        //     var rightHalf = array.TakeLast(length - (length / 2));
        //     if (length <= 2)
        //     {
        //         yield return array;
        //     }
        //     else
        //     {
        //         foreach (var item in ChopArray(leftHalf))
        //         {
        //             yield return item;
        //         }
        //         foreach (var item in ChopArray(rightHalf))
        //         {
        //             yield return item;
        //         }
        //     }
        // }
        // public static int countInversions(int[] array)
        // {
        //     // stolen from https://runzhuoli.me/2018/09/06/count-inversions-in-an-array.html
        //     return countInversions(array, new int[array.Length], 0, array.Length - 1);
        // }
        // private static int countInversions(int[] array, int[] temp, int leftStart, int rightEnd)
        // {
        //     if (leftStart >= rightEnd)
        //     {
        //         return 0;
        //     }
        //     int middle = (leftStart + rightEnd) / 2;
        //     int leftInversions = countInversions(array, temp, leftStart, middle);
        //     int rightInversions = countInversions(array, temp, middle + 1, rightEnd);
        //     int splitInversions = countSplitInversions(array, temp, leftStart, rightEnd);
        //     return leftInversions + rightInversions + splitInversions;
        // }
        // private static int countSplitInversions(int[] array, int[] temp, int leftStart, int rightEnd)
        // {
        //     int inversions = 0;
        //     int leftEnd = (leftStart + rightEnd) / 2;
        //     int lp = leftStart;
        //     int rp, rightStart;
        //     rp = rightStart = leftEnd + 1;
        //     for (int i = 0; i <= rightEnd - leftStart; i++)
        //     {
        //         if (lp > leftEnd)
        //         {
        //             temp[leftStart + i] = array[rp++];
        //         }
        //         else if (rp > rightEnd)
        //         {
        //             temp[leftStart + i] = array[lp++];
        //         }
        //         else
        //         {
        //             if (array[lp] < array[rp])
        //             {
        //                 temp[leftStart + i] = array[lp++];
        //             }
        //             else
        //             {
        //                 temp[leftStart + i] = array[rp++];
        //                 inversions += rightStart - lp;
        //             }
        //         }
        //     }
        //     Array.Copy(temp, leftStart, array, leftStart, rightEnd - leftStart + 1);
        //     return inversions;
        // }
    }
}