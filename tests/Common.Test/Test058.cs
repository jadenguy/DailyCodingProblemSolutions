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
        // [TestCase(3)] //it's dumb to even try and beat naive at this size, every operation counts here
        // [TestCase(100)] // too few tests to be actually faster
        // [TestCase(250)] // faster starts showing up here
        [TestCase(350)] // almost guaranteed to pass
        // [TestCase(500)] 
        // [TestCase(1000)] // almost double gains now
        public void Problem058WithComparison(int Count)
        {
            //-- Arrange
            const int Start = 0;
            int[] speedNaive = new int[Count * Count + 2];
            int[] speedDnC = new int[Count * Count + 2];

            //-- Act
            var time = Stopwatch.StartNew();
            var enumerable = Enumerable.Range(Start, Count).ToArray();
            for (int Delta = 0; Delta < Count; Delta++)
            {
                var array = enumerable.Select(k => (k + Delta) % Count).ToArray();
                for (int i = 0; i < Count; i++)
                {
                    var expected = (Count + i - Delta) % Count;
                    var actual = Solution058.FindRotatedSortedArrayIndexDivideAndConquor(array, i, out speedDnC[Delta * Count + i]);
                    Assert.AreEqual(expected, actual);
                }
            }
            var DnCTime = time.ElapsedMilliseconds;
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
            Assert.IsNull(Solution058.FindRotatedSortedArrayIndexNaive(enumerable, Start - 1, out speedNaive[Count * Count])); //below the list
            Assert.IsNull(Solution058.FindRotatedSortedArrayIndexNaive(enumerable, Start + Count + 1, out speedNaive[Count * Count + 1])); //above the list
            Assert.IsNull(Solution058.FindRotatedSortedArrayIndexDivideAndConquor(enumerable, Start - 1, out speedDnC[Count * Count])); //below the list
            Assert.IsNull(Solution058.FindRotatedSortedArrayIndexDivideAndConquor(enumerable, Start + Count + 1, out speedDnC[Count * Count + 1])); //above the list
            double averageDnCEval = speedDnC.Average();
            double averageNaiveEval = speedNaive.Average();
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine(naiveTime, "naiveTime");
            System.Diagnostics.Debug.WriteLine(DnCTime, "DnCTime");
            System.Console.WriteLine();
            System.Console.Write("naive time: ");
            System.Console.WriteLine(naiveTime);
            System.Console.Write("DnC time: ");
            System.Console.WriteLine(DnCTime);
            Assert.IsTrue(averageDnCEval.CompareTo(averageNaiveEval) < 0, "took longer");
            Assert.IsTrue(DnCTime.CompareTo(naiveTime) < 0, "took longer");
        }
    }
}