// Given a list, sort it using this method: reverse(lst, i, j), which reverses lst from i to j.

using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test147
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem147()
        {
            //-- Assert
            var array = Enumerable.Range(0,10).Shuffle().ToArray();
            var expected = Enumerable.Range(0,10).ToArray();

            //-- Arrange
            var actual = Solution147.SortWithReverseOnly(array);

            //-- Act
            Assert.AreEqual(expected,actual);
        }
    }
}
