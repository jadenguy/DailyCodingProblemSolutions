// You have n fair coins and you flip them all at the same time. Any that come up tails you set aside. The ones that come up heads you flip again. How many rounds do you expect to play before only one coin remains?
// Write a function that, given n, returns the number of rounds you'd expect to play until one coin remains.


using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test126
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, new int[] { 2, 3, 4, 5, 6, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 5, new int[] { 6, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, -4, new int[] { 3, 4, 5, 6, 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 2, new int[] { 3, 4, 5, 6, 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, new int[] { 3, 4, 5, 6, 7, 1, 2 })]
        public void Problem126Individually(int[] a, int k, int[] b)
        {
            //-- Arrange
            var expected = b;
            a.Print(",").WriteHost("input");
            k.WriteHost("rotations");
            b.Print(",").WriteHost("expected");

            //-- Act
            var actual = Solution126.RotateArray(a, k);
            actual.Print(",").WriteHost("Actual Flips");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}