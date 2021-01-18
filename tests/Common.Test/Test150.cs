// Given a list of points, a central point, and an integer k, find the nearest k points from the central point.

using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Common.Test
{
    public class Test150
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        //[Test]
        [TestCaseSource(typeof(Cases150))]
        public void Problem150((int x, int y)[] points, int k, (int x, int y)[] subsetOfGuaranteedResults, (int x, int y)[] subsetOfPossibleOtherResults)
        {
            //-- Assert
            var expectedCount = Math.Min(k, points.Distinct().Count());
            var guaranteedResults = new HashSet<(int x, int y)>(subsetOfGuaranteedResults);
            var allOtherPossibleResults = new HashSet<(int x, int y)>(subsetOfPossibleOtherResults);

            // for (int i = 0; i < 10; i++)
            // {
            //-- Arrange
            var returnedResults = Solution150.FindKClosestPoints(points.Distinct(), k).ToArray();
            var foundRequired = new HashSet<(int x, int y)>(returnedResults);
            foundRequired.IntersectWith(guaranteedResults);
            var foundPossible = new HashSet<(int x, int y)>(returnedResults);
            foundPossible.IntersectWith(allOtherPossibleResults);

            //-- Act
            Assert.IsTrue(guaranteedResults.IsSubsetOf(points) && allOtherPossibleResults.IsSubsetOf(points), "Your requested samples are not a part of the original list");
            Assert.IsFalse(guaranteedResults.Overlaps(allOtherPossibleResults), "Test input data contains one answer in multiple locations");
            Assert.AreEqual(guaranteedResults.Count, foundRequired.Count, "You are missing results that definitely would have been returned");
            Assert.AreEqual(expectedCount - guaranteedResults.Count, foundPossible.Count, "You are missing results from the subset of possible other results would have been returned");
            Assert.AreEqual(expectedCount, foundRequired.Count + foundPossible.Count, "Your result set it too small");
            // }
        }
        class Cases150 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new[] { (1, 1) }, 1, new[] { (1, 1) }, new (int, int)[] { } };
                yield return new object[] { new[] { (1, 1), (1, 2) }, 1, new[] { (1, 1) }, new (int, int)[] { } };
                yield return new object[] { new[] { (1, 1), (1, 2) }, 2, new[] { (1, 1), (1, 2) }, new (int, int)[] { } };
                yield return new object[] { new[] { (1, 1), (1, 2) }, 3, new[] { (1, 1), (1, 2) }, new (int, int)[] { } };
                yield return new object[] { new[] { (1, 3), (-2, 2) }, 1, new[] { (-2, 2) }, new (int, int)[] { } };
                yield return new object[] { new[] { (1, 1), (1, -1) }, 1, new (int, int)[] { }, new[] { (1, 1), (1, -1) } };
            }
        }
    }
}
