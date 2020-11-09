// Gray code <https://en.wikipedia.org/wiki/Gray_code>  is a binary code where each successive value differ in only one bit, as well as when wrapping around. Gray code is common in hardware so that we don't see temporary spurious values during transitions.
// Given a number of bits n, generate a possible gray code for it.

using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test148
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        // [TestCase(1)]
        // [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void Problem148(int bits)
        {
            //-- Assert
            int maxValue = (int)Math.Pow(2, bits);
            var testDigits = Enumerable.Range(0, maxValue);

            //-- Arrange
            int[] actual = Solution148.GenerateGrayCode(bits);

            //-- Act
            // test every consecutive set of numbers
            foreach (int a in testDigits)
            {
                int b = (a + 1) % maxValue;
                int v1 = actual[a];
                int v2 = actual[b];
                var delta = v1 ^ v2;
                var bitsDifferent = 0;
                for (int i = 0; i < bits; i++)
                {
                    var n = 1 << i;
                    int v = delta & n;
                    bool x = v != 0;
                    if (x) { bitsDifferent++; }
                }
                Assert.AreEqual(1, bitsDifferent, "value masks for a and b are not 1 digit different`");
            }
        }
    }
}
