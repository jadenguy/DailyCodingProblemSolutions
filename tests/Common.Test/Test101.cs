// Given an even number (greater than 2), return two prime numbers whose sum will be equal to the given number.
// A solution will always exist. See Goldbach’s conjecture.
// Example:
// Input: 4
// Output: 2 + 2 = 4
// If there are more than one solution possible, return the lexicographically smaller solution.
// If [a, b] is one solution with a <= b, and [c, d] is another solution with c <= d, then
// [a, b] < [c, d]
// If a < c OR a==c AND b < d.

using NUnit.Framework;

namespace Common.Test
{
    public class Test101
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(nameof(Cases))]
        public void Problem101(int value, int lesserPrime, int greaterPrime)
        {
            //-- Arrange
            var expected = (lesserPrime, greaterPrime);

            //-- Act
            (int, int) actual = Solution101.PrimePairSumTo(value);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        static object[] Cases = {
            new object[]{100,3,97},
            new object[]{20,3,17},
            new object[]{22,3,19},
            new object[]{4,2,2},
        };
    }
}
