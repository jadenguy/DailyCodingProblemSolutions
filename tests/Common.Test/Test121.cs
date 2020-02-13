// Given a string which we can delete at most k, return whether you can make a palindrome.
// For example, given 'waterrfetawx' and a k of 2, you could delete f and x to get 'waterretaw'.


using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test121
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase("waterrfetawx", 2, true)]
        [TestCase("waterrfetawx", 1, false)]
        public void Problem121(string input, int deletionMax, bool isPossible)
        {
            //-- Arrange
            var expected = isPossible;
            input.WriteHost("Source");
            deletionMax.WriteHost("Deletions");
            expected.WriteHost("Expected");

            //-- Act
            bool actual = Solution121.PalindromeDeletionPossible(input, deletionMax);
            actual.WriteHost("Actual");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}