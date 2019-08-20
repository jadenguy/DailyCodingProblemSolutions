// An sorted array of integers was rotated an unknown number of times.
// Given such an array, find the index of the element in the array in faster than linear time. If the element doesn't exist in the array, return null.
// For example, given the array [13, 18, 25, 2, 8, 10] and the element 8, return 4 (the index of 8 in the array).
// You can assume all the integers in the array are unique.

using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test058
    {
        // [SetUp] public void SetUp() { }
        [Test]
        // [TestCase(3)]
        // [TestCase(100)] // too few tests to be actually faster
        [TestCase(250)] // faster starts showing up here
        // [TestCase(500)] 
        // [TestCase(1000)] // almost double now
        public void Problem058WithComparison(int Count)
        {
            //-- Arrange
            const int Start = 0;
            int[] speedNaive = new int[Count * Count + 2];
            int[] speedComplex = new int[Count * Count + 2];

            //-- Act
            var time = Stopwatch.StartNew();
            var enumerable = Enumerable.Range(Start, Count).ToArray();
            for (int Delta = 0; Delta < Count; Delta++)
            {
                var array = enumerable.Select(k => (k + Delta) % Count).ToArray();
                for (int i = 0; i < Count; i++)
                {
                    var expected = (Count + i - Delta) % Count;
                    var actual = Solution058.FindRotatedSortedArrayIndexDivideAndConquor(array, i, out speedComplex[Delta * Count + i]);
                    Assert.AreEqual(expected, actual);
                }
            }
            var complexTime = time.ElapsedMilliseconds;

            time = Stopwatch.StartNew();
            for (int Delta = 0; Delta < Count; Delta++)
            {
                var array = enumerable.Select(k => (k + Delta) % Count).ToArray();
                for (int i = 0; i < Count; i++)
                {
                    var expected = (Count + i - Delta) % Count;
                    var actual = Solution058.FindRotatedSortedArrayIndexNaive(array, i, out speedNaive[Delta * Count + i]);
                    Assert.AreEqual(expected, actual);
                }
            }
            var naiveTime = time.ElapsedMilliseconds;

            //-- Assert
            Assert.IsNull(Solution058.FindRotatedSortedArrayIndexNaive(enumerable, Start - 1, out speedNaive[Count * Count]));
            Assert.IsNull(Solution058.FindRotatedSortedArrayIndexNaive(enumerable, Start + Count + 1, out speedNaive[Count * Count + 1]));
            Assert.IsNull(Solution058.FindRotatedSortedArrayIndexDivideAndConquor(enumerable, Start - 1, out speedComplex[Count * Count]));
            Assert.IsNull(Solution058.FindRotatedSortedArrayIndexDivideAndConquor(enumerable, Start + Count + 1, out speedComplex[Count * Count + 1]));
            double averageComplexEval = speedComplex.Average();
            double averageNaiveEval = speedNaive.Average();
            Assert.IsTrue(averageComplexEval.CompareTo(averageNaiveEval) < 0, "took longer");
            Assert.IsTrue(complexTime.CompareTo(naiveTime) < 0, "took longer");
            System.Diagnostics.Debug.WriteLine(naiveTime, "naiveTime");
            System.Diagnostics.Debug.WriteLine(complexTime, "complexTime");
            System.Console.WriteLine(naiveTime);
            System.Console.WriteLine(complexTime);

        }
    }
}