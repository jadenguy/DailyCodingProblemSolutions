// Given an array of integers in which two elements appear exactly once and all other elements appear exactly twice, find the two elements that appear only once.
// For example, given the array [2, 4, 6, 8, 10, 2, 6, 10], return 4 and 8. The order does not matter.

using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Common.Test
{
    public class Test140
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases140))]
        public void Problem140(int[] array, int[] singles)
        {
            //-- Assert
            var expected = new HashSet<int>(singles);

            //-- Arrange
            var actual = new HashSet<int>(Solution140.FindUniquePair(array));

            //-- Act
            Assert.IsTrue(expected.SetEquals(actual), "sets unequal");
        }
        internal class Cases140 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new[] { 2, 4, 6, 8, 10, 2, 6, 10 }, new[] { 4, 8 } };
            }
        }
    }
}