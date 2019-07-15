// Compute the running median of a sequence of numbers. That is, given a stream of numbers, print out the median of the list so far on each new element.
// Recall that the median of an even-numbered list is the average of the two middle numbers.
// For example, given the sequence [2, 1, 5, 7, 2, 0, 5], your algorithm should print out:
// 2
// 1.5
// 2
// 3.5
// 2
// 2
// 2

using NUnit.Framework;

namespace Common.Test
{
    public class Test033
    {

        [SetUp]
        public void Setup() { }
        [TearDown]
        public void TearDown() { }
        [Test]
        [TestCase(new double[] { 2, 1, 5, 7, 2, 0, 5 }, new double[] { 2, 1.5, 2, 3.5, 2, 2, 2 })]
        public void Problem33(double[] array, double[] results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var actual = Solution33.StreamMedian(array);
            // arrayStream = array.StreamSlowly(1000);
            // var printOut = Solution33.StreamMedian(arrayStream);
            // foreach (var item in printOut)
            // {
            //     System.Diagnostics.Debug.WriteLine(item);
            // }
            
            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}