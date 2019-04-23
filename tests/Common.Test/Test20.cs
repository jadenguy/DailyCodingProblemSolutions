// For example, given A = 3 -> 7 -> 8 -> 10 and B = 99 -> 1 -> 8 -> 10, return the node with value 8.
// In this example, assume nodes with the same value are the exact same node objects.
// Do this in O(M + N) time (where M and N are the lengths of the lists) and constant space.
using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test20
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 3, 7, 8, 10 }, new int[] { 99, 1, 8, 10 }, 8)]
        public void Problem20(int[] a, int[] b, int common)
        {
            //-- Arrange
            var expected = common;

            //-- Act
            var actual = Solution20.FindCommonNode(a, b);

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}