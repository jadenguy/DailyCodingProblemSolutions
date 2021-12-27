// Implement a stack API using only a heap. A stack implements the following methods:
// *	push(item), which adds an element to the stack
// *	pop(), which removes and returns the most recently added element (or throws an error if there is nothing on the stack)
// Recall that a heap has the following operations:
// *	push(item), which adds a new key to the heap
// *	pop(), which removes and returns the max value of the heap

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test154
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        // [Test]
        public void Problem154()
        {
            //-- Assert
            var expected = Enumerable.Range(1, 100);
            var input = expected.Select(t => 100 - t);

            //-- Arrange
            var actual = new Common.Solution154.Stack<int>(input);

            //-- Act
            Assert.AreEqual(expected, actual);
        }
    }
}
