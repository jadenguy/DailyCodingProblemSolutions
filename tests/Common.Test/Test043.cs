// Implement a stack that has the following methods:

// push(val), which pushes an element onto the stack
// pop(), which pops off and returns the topmost element of the stack. If there are no elements in the stack, then it should throw an error or return null.
// max(), which returns the maximum value in the stack currently. If there are no elements in the stack, then it should throw an error or return null.
// Each method should run in constant time.

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
            var stack = new Common.Stack<int>();
            //-- Act

            var actual = stack;

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem043PushOne()
        {
            //-- Arrange
            var expected = new int[] {1 };
            var stack = new Common.Stack<int>();
            //-- Act

            stack.Push(1);
            var actual = stack;

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
                [Test]
        public void Problem043PopOne()
        {
            //-- Arrange
            var expected = 1;
            var stack = new Common.Stack<int>();
            //-- Act

            stack.Push(1);
            var actual = stack.Pop();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]public void Problem043PeekOne()
        {
            //-- Arrange
            var expected = 1;
            var stack = new Common.Stack<int>();
            //-- Act

            stack.Push(1);
            var actual = stack.Peek();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}