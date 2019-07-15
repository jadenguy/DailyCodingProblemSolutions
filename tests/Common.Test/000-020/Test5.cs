// cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair. For example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.
// Given this implementation of cons:
// def cons(a, b):
//     def pair(f):
//         return f(a, b)
//     return pair
// Implement car and cdr.

using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test005
    {

        [Test]
        [TestCase(1, 2)]
        public void Problem5Car(int a,int b)
        {
            //-- Arrange
            
            var expectedCar = a;
            var expectedCdr = b;

            //-- Act
            var actualCar = Solution5.Car(Solution5.Cons(a,b));
            var actualCdr = Solution5.Cdr(Solution5.Cons(a,b));

            //-- Assert
            Assert.AreEqual(expectedCar, actualCar);
            Assert.AreEqual(expectedCdr, actualCdr);
        }
    }
}