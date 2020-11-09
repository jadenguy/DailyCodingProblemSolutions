// Given a list of numbers L, implement a method sum(i, j) which returns the sum from the sublist L[i:j] (including i, excluding j).
// For example, given L = [1, 2, 3, 4, 5], sum(1, 3) should return sum([2, 3]), which is 5.

using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;
using System.Collections;

namespace Common.Test
{
    public class Test149
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [TestCaseSource(typeof(Cases149))]
        public void Problem149(int[] L, int i, int j, int answer)
        {
            //-- Assert
            var expected = answer;

            //-- Arrange
            var actual = Solution149.Sum(L, i, j);

            //-- Act
            Assert.AreEqual(expected, actual);
        }
        class Cases149 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var L = new[] { 1, 2, 3, 4, 5 };
                int a = 1;
                int b = 3;
                var result = 5;
                yield return new object[] { L, a, b, result };
            }
        }
    }
}
