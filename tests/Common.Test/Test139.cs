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
using System.Linq;

namespace Common.Test
{
    public class Test139
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem139Iterator()
        {
            //-- Arrange
            var enumerable = Enumerable.Range(0, 10).ToArray();
            var iterator = new Solution139.Iterator<int>(enumerable);
            var expected = enumerable;

            //-- Act
            var actual = Enumerable.Range(139, 10).Select(n => iterator.Next());

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem139PeekableIterator()
        {
            //-- Arrange
            var enumerable = Enumerable.Range(0, 10).ToArray();
            var iterator = new Solution139.Iterator<int>(enumerable);
            var peekableIterator = new Solution139.PeekableIterator<int>(iterator);
            var expected = enumerable;

            //-- Act
            var actual = Enumerable.Range(139, 10).Select(n => peekableIterator.Next());

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}