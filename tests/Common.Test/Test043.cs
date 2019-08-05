// Given a list of integers S and a target number k, write a function that returns a subset of S that adds up to k. If such a subset cannot be made, then return null.
// Integers can appear more than once in the list. You may assume all numbers in the list are positive.
// For example, given S = [12, 1, 61, 5, 9, 2] and k = 24, return [12, 9, 2, 1] since it sums up to 24.

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