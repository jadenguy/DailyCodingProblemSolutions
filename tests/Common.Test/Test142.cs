// You're given a string consisting solely of (, ), and *. * can represent either a (, ), or an empty string. Determine whether the parentheses are balanced.

using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;
using System.Collections.Generic;
using System.Collections;

namespace Common.Test
{
    public class Test142
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases142))]
        public void Problem142(string input, bool balanced)
        {
            //-- Assert
            var expected = balanced;

            //-- Arrange
            bool actual = Solution142.IsBalanced(input);

            //-- Act
            Assert.AreEqual(expected, actual);
        }
        private class Cases142 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { "*)", true };
                // passing
                yield return new object[] { "", true };
                yield return new object[] { "*", true };
                yield return new object[] { "**", true };
                yield return new object[] { "***", true };
                yield return new object[] { "(*", true };
                yield return new object[] { "(*)", true };
                yield return new object[] { "(**)", true };
                yield return new object[] { "(", false };
                yield return new object[] { ")", false };
                yield return new object[] { "((", false };
                yield return new object[] { "(()", false };
                yield return new object[] { ")()", false };
                yield return new object[] { "))", false };
                yield return new object[] { ")(", false };
                yield return new object[] { "(())", true };
                yield return new object[] { "(()())", true };
                yield return new object[] { "((()))", true };
            }
        }
    }
}
