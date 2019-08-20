// An sorted array of integers was rotated an unknown number of times.
// Given such an array, find the index of the element in the array in faster than linear time. If the element doesn't exist in the array, return null.
// For example, given the array [13, 18, 25, 2, 8, 10] and the element 8, return 4 (the index of 8 in the array).
// You can assume all the integers in the array are unique.

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test058
    {
        // [SetUp] public void SetUp() { }
        [Test]
        public void Problem058WithComparison()
        {
            //-- Arrange
            const int Count = 111;
            const int Delta = 13;
            var array = Enumerable.Range(0, Count).Select(k => (k + Delta) % Count).ToArray();
            int[] speedNaive = new int[Count];
            int[] speedComplex = new int[Count];
            //-- Act

            for (int i = 0; i < Count; i++)
            {
                var expected = (Count + i - Delta) % Count;
                var actualNaive = Solution058.FindRotatedSortedArrayIndexNaive(array, i, out var naive);
                speedNaive[i] = naive;
                var actualComplex = Solution058.FindRotatedSortedArrayIndexDivideAndConquor(array, i, out var complex);
                speedComplex[i] = complex;
                Assert.AreEqual(expected, actualNaive);
                Assert.AreEqual(expected, actualComplex);
            }

            //-- Assert
            double averageComplexEval = speedComplex.Average();
            double averageNaiveEval = speedNaive.Average();
            Assert.IsTrue(averageComplexEval.CompareTo(averageNaiveEval) < 0, "took longer");
        }
    }
}