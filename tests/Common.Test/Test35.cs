// Given an array of strictly the characters 'R', 'G', and 'B', segregate the values of the array so that all the Rs come first, the Gs come second, and the Bs come last. You can only swap elements of the array.
// Do this in linear time and in-place.
// For example, given the array ['G', 'B', 'R', 'R', 'B', 'R', 'G'}, it should become ['R', 'R', 'R', 'G', 'G', 'B', 'B'}.

using NUnit.Framework;

namespace Common.Test
{
    public class Test035
    {

        [SetUp]
        public void Setup() { System.Diagnostics.Debug.WriteLine(""); }
        [TearDown]
        public void TearDown() { }
        [Test]
        [TestCase(new char[] { 'G', 'B', 'R', 'R', 'B', 'R', 'G' }, new char[] { 'R', 'R', 'R', 'G', 'G', 'B', 'B' })]
        [TestCase(new char[] { 'G', 'G', 'G', 'G', 'G', 'R', 'R', 'R', 'R', 'R' }, new char[] { 'R', 'R', 'R', 'R', 'R', 'G', 'G', 'G', 'G', 'G' })]
        [TestCase(new char[] { 'B', 'G', 'G', 'G', 'G' }, new char[] { 'G', 'G', 'G', 'G', 'B' })]
        [TestCase(new char[] { 'G', 'B', 'B', 'B', 'B' }, new char[] { 'G', 'B', 'B', 'B', 'B' })]
        public void Problem33(char[] array, char[] results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var actual = Solution35.SortRGB(array);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}