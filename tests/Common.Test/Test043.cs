// Implement a stack that has the following methods:

// push(val), which pushes an element onto the stack
// pop(), which pops off and returns the topmost element of the stack. If there are no elements in the stack, then it should throw an error or return null.
// max(), which returns the maximum value in the stack currently. If there are no elements in the stack, then it should throw an error or return null.
// Each method should run in constant time.

using System.Linq;
using Common.Collections;
using NUnit.Framework;

namespace Common.Test
{
    public class Test043
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem043ListEmpty()
        {
            //-- Arrange
            var expected = new int[] { };
            var stack = new Stack<int>();
            //-- Act

            var actual = stack.ToArray();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem043PushOne()
        {
            //-- Arrange
            var expected = new int[] { 1 };
            var stack = new Stack<int>();
            //-- Act

            stack.Push(1);
            var actual = stack.ToArray();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem043PushOneTwo()
        {
            //-- Arrange
            var expected = new int[] { 1, 2 };
            var stack = new Stack<int>();

            //-- Act
            stack.Push(1);
            stack.Push(2);
            var actual = stack.ToArray();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem043PushMultipleValues()
        {
            //-- Arrange
            int values = 5000;
            var expected = Enumerable.Range(0, values).ToArray();
            var stack = new Stack<int>();

            //-- Act
            for (int i = 0; i < values; i++)
            {
                stack.Push(i);
            }
            var actual = stack.ToArray();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem043PopOne()
        {
            //-- Arrange
            var expected = 1;
            var stack = new Stack<int>();

            //-- Act
            stack.Push(1);
            var actual = stack.Pop();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem043PeekOne()
        {
            //-- Arrange
            var expected = 1;
            var stack = new Stack<int>();

            //-- Act
            stack.Push(1);
            var actual = stack.Peek();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}