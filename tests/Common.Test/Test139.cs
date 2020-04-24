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
using System.Collections.Generic;
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
            var series = Enumerable.Range(0, 10);
            var iterator = new Solution139.Iterator<int>(series);
            var expected = series;

            //-- Act
            var actual = series.Select(n => iterator.Next());

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem139PeekableIteratorOnceThrough()
        {
            //-- Arrange
            var series = Enumerable.Range(0, 10);
            var iterator = new Solution139.Iterator<int>(series);
            var peekableIterator = new Solution139.PeekableIterator<int>(iterator);
            var expected = series;

            //-- Act
            var actual = series.Select(n => peekableIterator.Next());

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem139PeekableIteratorRepeatPeak()
        {
            //-- Arrange
            var rand = new System.Random(139);
            var series = Enumerable.Range(0, 10);
            var iterator = new Solution139.Iterator<int>(series);
            var peekableIterator = new Solution139.PeekableIterator<int>(iterator);
            var expected = series.SelectMany(n => Enumerable.Repeat(n, n));

            //-- Act
            var actual = new List<int>();
            foreach (var i in series)
            {
                for (int j = 0; j < i; j++)
                {
                    actual.Add(peekableIterator.PeekNext());
                }
                peekableIterator.Next();
            }
            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}