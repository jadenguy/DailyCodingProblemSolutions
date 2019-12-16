// Given a number in the form of a list of digits, return all possible permutations.
// For example, given [1,2,3], return [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]].

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test096
    {
        List<int[]> numbers;
        List<int[][]> permutations;
        [SetUp]
        public void Setup()
        {
            numbers = new List<int[]>();
            permutations = new List<int[][]>();
            numbers.Add(new int[] { 1, 2, 3 });
            permutations.Add(new int[6][] { new int[] { 1, 2, 3 },new int[] { 1, 3, 2 }, new int[] { 2, 1, 3 }, new int[] { 2, 3, 1 }, new int[] { 3, 1, 2 }, new int[] { 3, 2, 1 } });
            // 0
        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase()]
        public void Problem096(int testCase = 0)
        {
            //-- Arrange
            var expected = permutations[testCase].OrderBy(e => e, new ComperableArrayComparer<int>()).ToArray();
            var number = numbers[testCase];

            //-- Act
            var actual = Solution096.Permutations(number).OrderBy(a => a, new ComperableArrayComparer<int>()).ToArray();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
