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
        [TestCaseSource("Case0")]
        public void Problem101(int value, (int, int) primePair)
        {
            //-- Arrange
            var expected = primePair;

            //-- Act
            (int, int) actual = Solution101.PrimePairSumTo(value);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        static object[] Case0 = {
            new object[]{4,(2,2)}
        };
    }
}
