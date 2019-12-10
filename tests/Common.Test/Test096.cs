// Given a binary tree of integers, find the maximum path sum between two nodes. The path must go through at least one node, and does not need to go through the root.

using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test096
    {
        List<int[]> numbers;
        List<int[,]> permutations;
        [SetUp]
        public void Setup()
        {
            numbers = new List<int[]>();
            permutations = new List<int[,]>();
            numbers.Add(new int[] { 1, 2, 3 });
            permutations.Add(new int[,]{{1,2,3},{1,3,2},{2,1,3},{2,3,1},{3,1,2},{3,2,1}});
            // 0
        }
        // [TearDown] public void TearDown() { }
        [Test]
        // [TestCase()]
        public void Problem096(int testCase = 0)
        {
            //-- Arrange
            var expected = permutations[testCase];
            var number = numbers[testCase];

            //-- Act
            int[,] actual = Solution096.Permutations(number);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
