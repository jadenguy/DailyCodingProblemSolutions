// Given a list of points, a central point, and an integer k, find the nearest k points from the central point.

using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Common.Test
{
    public class Test150
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        //[Test]
        [TestCaseSource(typeof(Cases150))]
        public void Problem150((int x, int y)[] points, int k, (int x, int y)[] results)
        {
            //-- Assert
            var expected = new HashSet<(int x, int y)>(results);

            //-- Arrange
            var actual = Solution150.FindKClosestPoints(points, k);

            //-- Act
            Assert.IsTrue(expected.SetEquals(actual));
        }
        class Cases150 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new[] { (1, 1) }, 1, new[] { (1, 1) } };
                yield return new object[] { new[] { (1, 1), (1, 2) }, 1, new[] { (1, 1) } };
                yield return new object[] { new[] { (1, 1), (1, 2) }, 2, new[] { (1, 1), (1, 2) } };
                yield return new object[] { new[] { (1, 1), (1, 2) }, 3, new[] { (1, 1), (1, 2) } };
                yield return new object[] { new[] { (1, 3), (-2, 2) }, 1, new[] { (-2, 2) } };
                yield break;
            }
        }
    }
}
