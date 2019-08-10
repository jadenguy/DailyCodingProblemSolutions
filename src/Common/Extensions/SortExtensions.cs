using System;
using System.Collections.Generic;
using System.Linq;
using Common.Algorithm;

namespace Common.Extensions
{
    public static class SortExtensions
    {
        public static IEnumerable<T> MergeSort<T>(this IEnumerable<T> array)
            where T : IComparable<T>
        {
            // IEnumerable<T> x = Merge<T>(array, array);
            
            // var ret = DnC.DivideAndConquor<T>(array, Merge<T>);
            throw new Exception();
            // return ;
        }
        public static IEnumerable<T> MergeSortMeasure<T>(this IEnumerable<T> array, ref int swaps) where T : IComparable<T>
        {
            int length = array.Count();
            int smallHalf = length / 2;
            int bigHalf = length - smallHalf;
            var leftHalf = array.Take(bigHalf);
            var rightHalf = array.TakeLast(smallHalf);
            IEnumerable<T> sortedLeft = leftHalf;
            IEnumerable<T> sortedRight = rightHalf;
            // System.Diagnostics.Debug.WriteLine(sortedLeft.Print(","), "l half");
            // System.Diagnostics.Debug.WriteLine(rightHalf.Print(","), "r half");
            if (length > 2)
            {
                // System.Diagnostics.Debug.WriteLine("recurse");
                // System.Diagnostics.Debug.WriteLine("");
                sortedLeft = MergeSortMeasure(leftHalf, ref swaps);
                sortedRight = MergeSortMeasure(rightHalf, ref swaps);
            }
            // System.Diagnostics.Debug.WriteLine("merging");
            // System.Diagnostics.Debug.WriteLine("");
            return MergeMeasure(sortedLeft, sortedRight, ref swaps);
        }
        private static IEnumerable<T> Merge<T>(IEnumerable<T> leftHalf, IEnumerable<T> rightHalf)
            where T : IComparable<T>
        {
            var x = 0;
            return MergeMeasure(leftHalf, rightHalf, ref x);
        }
        private static IEnumerable<T> MergeMeasure<T>(this IEnumerable<T> leftHalf, IEnumerable<T> rightHalf, ref int swaps) where T : IComparable<T>
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
                        // System.Diagnostics.Debug.WriteLine($"{left} less than {right}");
                    }
                    else
                    {
                        { ret.Add(r.Dequeue()); }
                        swaps += l.Count;
                        // System.Diagnostics.Debug.WriteLine($"{right} less than {left}, swap measure {Swaps}");
                    }
                }
                else if (lExists)
                {
                    ret.Add(l.Dequeue());
                    // System.Diagnostics.Debug.WriteLine($"right empty, adding {left}");
                }
                else if (rExists)
                {
                    ret.Add(r.Dequeue());
                    // System.Diagnostics.Debug.WriteLine($"left empty, adding {right}");
                }
                else { keepGoing = false; }
            } while (keepGoing);
            // System.Diagnostics.Debug.Write("Merged to: ");
            // System.Diagnostics.Debug.WriteLine(ret.Print(","));
            return ret;
        }
    }
}