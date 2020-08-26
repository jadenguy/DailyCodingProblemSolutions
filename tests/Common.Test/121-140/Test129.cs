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
        private static object[] NegativeTest(double value)
        {
            double square = -1 * value * value;
            Complex complex = value * Complex.ImaginaryOne;
            return new object[] { square, complex };
        }
        private static object[] PositiveTest(double value)
        {
            double square = value * value;
            Complex complex = value;
            return new object[] { square, complex };
        }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem129(double sqRt) => TestProblem129(NegativeTest(sqRt));
        private void TestProblem129(object[] vs) => TestProblem129((double)vs[0], (Complex)vs[1]);
        public void TestProblem129(double n, Complex sqRt)
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
                yield return 12345;
                yield return Math.PI;
                yield return 2;
                yield return 1;
                yield return .5;
                yield return 0;
                yield return .25;
                yield return .3;
                yield return .5;
                yield return 1;
                yield return 3;
                yield return 1.5;
                yield break;
            }
        }
    }
}