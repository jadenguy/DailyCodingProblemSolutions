using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
namespace Common
{
    public class Solution044
    {


        // 
        private int swaps = 0;

        public int Swaps
        {
            get => swaps; set
            {
                swaps = value;
            }
        }

        public T[] CountSorts<T>(T[] array) where T : IComparable<T>
        {
            var newArray = MergeSort(array).ToArray();
            return newArray;
        }
        public IEnumerable<T> MergeSort<T>(IEnumerable<T> array) where T : IComparable<T>
        {
            int length = array.Count();
            int smallHalf = length / 2;
            int bigHalf = length - smallHalf;
            var leftHalf = array.Take(bigHalf);
            var rightHalf = array.TakeLast(smallHalf);
            IEnumerable<T> sortedLeft = leftHalf;
            IEnumerable<T> sortedRight = rightHalf;
            if (length > 2)
            {
                System.Diagnostics.Debug.WriteLine("recurse");
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine(sortedLeft.Print(","), "l half");
                sortedLeft = MergeSort(leftHalf);
                System.Diagnostics.Debug.WriteLine(rightHalf.Print(","), "r half");
                sortedRight = MergeSort(rightHalf);
            }
            System.Diagnostics.Debug.WriteLine("merging");
            System.Diagnostics.Debug.WriteLine("");
            return Merge(sortedLeft, sortedRight);
        }

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

        private IEnumerable<T> Merge<T>(IEnumerable<T> leftHalf, IEnumerable<T> rightHalf) where T : IComparable<T>
        {
            // System.Diagnostics.Debug.WriteLine(leftHalf.Print(","), "l half");
            // System.Diagnostics.Debug.WriteLine(rightHalf.Print(","), "r half");
            var l = new Queue<T>(leftHalf);
            var r = new Queue<T>(rightHalf);
            var ret = new List<T>();
            bool keepGoing = true;
            do
            {
                var lExists = l.TryPeek(out T left);
                var rExists = r.TryPeek(out T right);
                if (lExists && rExists)
                {
                    if (left.CompareTo(right) < 0)
                    {
                        ret.Add(l.Dequeue());
                        System.Diagnostics.Debug.WriteLine($"{left} less than {right}");
                    }
                    else
                    {
                        { ret.Add(r.Dequeue()); }
                        Swaps += l.Count;
                        System.Diagnostics.Debug.WriteLine($"{right} less than {left}, swap {Swaps}");
                    }
                }
                else if (lExists)
                {
                    ret.Add(l.Dequeue());
                    System.Diagnostics.Debug.WriteLine($"right empty, adding {left}");
                }
                else if (rExists)
                {
                    ret.Add(r.Dequeue());
                    System.Diagnostics.Debug.WriteLine($"left empty, adding {right}");
                }
                else { keepGoing = false; }
            } while (keepGoing);
            System.Diagnostics.Debug.Write("Merged to: ");
            System.Diagnostics.Debug.WriteLine(ret.Print(","));
            return ret;
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
