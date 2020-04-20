// This problem was asked by Google.
// Given an iterator with methods next() and hasNext(), create a wrapper iterator, PeekableInterface, which also implements peek(). peek shows the next element that would be returned on next().
// Here is the interface:
// class PeekableInterface(object):
//     def __init__(self, iterator):
//         pass

//     def peek(self):
//         pass

//     def next(self):
//         pass

//     def hasNext(self):
//         pass




using NUnit.Framework;
using System.Collections;
using System.Linq;

namespace Common.Test
{
    public class Test139
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem139(int[] denominations, int n, int result)
        {
            //-- Arrange
            var iterator = new Solution139.Iterator<int>(Enumerable.Range(0,10));
            var expected = result;

            //-- Act
            int actual = new Solution139.

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                int[] american = new int[] { 1, 5, 10, 25 };
                yield return new object[] { american, 16, 3 };
                yield return new object[] { new int[] { 9, 6, 5, 1 }, 11, 2 };
            }
        }
    }
}