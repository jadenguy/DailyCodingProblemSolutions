// Given a real number n, find the square root of n. For example, given n = 9, return 3

using System;
using System.Collections;
using System.Numerics;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test129
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem129(double n, Complex sqRt)
        {
            //-- Arrange
            var expected = sqRt;
            n.WriteHost("Square");
            expected.WriteHost("Square Root");

            //-- Act
            var actual = Solution129.SqRt(n);
            actual.WriteHost("Calculated Square Root");

            // //-- Assert
            Assert.AreEqual(expected.Real, actual.Real, .0000001 * sqRt.Real, "Real Component Accurate");
            Assert.AreEqual(expected.Imaginary, actual.Imaginary, .0000001 * sqRt.Imaginary, "Imaginary Component Wrong");
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { -12345 * 12345, 12345 * Complex.ImaginaryOne };
                yield return new object[] { -Math.PI * Math.PI, Math.PI * Complex.ImaginaryOne };
                yield return new object[] { -4, 2 * Complex.ImaginaryOne };
                yield return new object[] { -1, 1 * Complex.ImaginaryOne };
                yield return new object[] { -.25, .5 * Complex.ImaginaryOne };
                yield return new object[] { 0, 0 * Complex.ImaginaryOne };
                yield return new object[] { .0625, .25 * Complex.One };
                yield return new object[] { .09, .3 * Complex.One };
                yield return new object[] { .25, .5 * Complex.One };
                yield return new object[] { 1, 1 * Complex.One };
                yield return new object[] { 9, 3 * Complex.One };
                yield return new object[] { 2.25, 1.5 * Complex.One };
                yield break;
            }
        }
    }
}