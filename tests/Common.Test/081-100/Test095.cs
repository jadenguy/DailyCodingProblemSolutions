// Given a number represented by a list of digits, find the next greater permutation of a number, in terms of lexicographic ordering. If there is not greater permutation possible, return the permutation with the lowest value/ordering.
// For example, the list [1,2,3] should return [1,3,2]. The list [1,3,2] should return [2,1,3]. The list [3,2,1] should return [1,2,3].
// Can you perform the operation without allocating extra memory (disregarding the input memory)?

using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test095
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }

        [Test]
        [TestCase(new int[] { 1, 3, 2, 1 }, new int[] { 2, 1, 1, 3 })]
        [TestCase(new int[] { 1, 1, 5, 6, 4, 2, 1 }, new int[] { 1, 1, 6, 1, 2, 4, 5 })]
        [TestCase(new int[] { 1, 3, 2 }, new int[] { 2, 1, 3 })]
        [TestCase(new int[] { 1, 2, 2, 2, 2 }, new int[] { 2, 1, 2, 2, 2 })]
        [TestCase(new int[] { 1, 2, 2 }, new int[] { 2, 1, 2 })]
        [TestCase(new int[] { 1, 1, 2 }, new int[] { 1, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 })]
        [TestCase(new int[] { 1, 1, 1, 1, 2 }, new int[] { 1, 1, 1, 2, 1 })]
        [TestCase(new int[] { 2, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 2 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 2, 2, 2, 2, 1 }, new int[] { 1, 2, 2, 2, 2 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [TestCase(new int[] { 2, 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 1 }, new int[] { 1, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void Problem095(int[] input, int[] output)
        {
            //-- Arrange
            var expected = output;

            //-- Act
            // System.Diagnostics.Debug.WriteLine("new run");

            System.Diagnostics.Debug.WriteLine(input.Print(", "), "source");
            var actual = (int[])input.Clone();
            Solution095.NextLexicographically(actual);
            System.Diagnostics.Debug.WriteLine(actual.Print(", "), "result");
            System.Diagnostics.Debug.WriteLine(output.Print(", "), "expected");

            System.Diagnostics.Debug.WriteLine(expected.SequenceEqual(actual), "worked");
            System.Diagnostics.Debug.WriteLine("");
            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}