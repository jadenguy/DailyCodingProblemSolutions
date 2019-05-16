// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
// For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
// Bonus: Can you do this in one pass?

using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test24
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Problem24(int[] list, int[] answer)
        {
            //-- Arrange
            var node = new LockingBinaryNode("root");
            var expected = true;

            //-- Act
            var actual = node.TryLock();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}