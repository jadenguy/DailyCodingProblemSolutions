using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Test9
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 2, 4, 6, 2, 5 }, 13)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 5, 1, 1, 5 }, 10)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 3 }, 3)]
        public void Problem9(int[] list, int answer)
        {
            //-- Arrange
            var expected = answer;

            //-- Act
            var actual = Common.Solution9.LargestSumNonAdjacent(list);

            //-- Assert
            Assert.AreEqual(actual, expected);

        }
    }
}