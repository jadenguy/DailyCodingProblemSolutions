// Given an array of strictly the characters 'R', 'G', and 'B', segregate the values of the array so that all the Rs come first, the Gs come second, and the Bs come last. You can only swap elements of the array.
// Do this in linear time and in-place.
// For example, given the array ['G', 'B', 'R', 'R', 'B', 'R', 'G'}, it should become ['R', 'R', 'R', 'G', 'G', 'B', 'B'}.

using NUnit.Framework;

namespace Common.Test
{
    public class Test34
    {

        [SetUp]
        public void Setup() { }
        [TearDown]
        public void TearDown() { }
        [Test]
        [TestCase(new char[] { 'G', 'B', 'R', 'R', 'B', 'R', 'G' }, new char[] { 'R', 'R', 'R', 'G', 'G', 'B', 'B' })]
        public void Problem33(char[] array, char[] results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var actual = Solution34.SortRGB(array);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}