using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Test2
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 120, 60, 40, 30, 24 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 2, 3, 6 })]
        public void Problem2(int[] list, int[] answer)
        {
            //-- Arrange
            var expected = answer;

            //-- Act
            var actual = Common.Solution2.ProductOfOther(list);

            //-- Assert
            Assert.AreEqual(actual, expected);

        }
    }
}