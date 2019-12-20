// Given a string and a set of characters, return the shortest substring containing all the characters in the set.
// For example, given the string "figehaeci" and the set of characters {a, e, i}, you should return "aeci".
// If there is no substring containing all the characters in the set, return null.

using NUnit.Framework;

namespace Common.Test
{
    public class Test103
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(nameof(Cases))]
        public void Problem103(int[] list, int k, int[] results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var actual = Solution103.ShortestInclusiveSubset(list, k);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        static object[] Cases = {
            new object[]{new int []{1, 2, 3, 4, 5},9,new int[]{2, 3, 4}}
        };
    }
}
