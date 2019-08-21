// Implement a queue using two stacks. Recall that a queue is a FIFO (first-in, first-out) data structure with the following methods: enqueue, which inserts an element into the queue, and dequeue, which removes it.

using System.Linq;
using Common.Collections;
using NUnit.Framework;

namespace Common.Test
{
    public class Test053
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem053()
        {
            //-- Arrange
            const string a = "A";
            const string b = "B";
            var queue = new StackQueue<string>();

            //-- Act
            queue.Enqueue(a);
            queue.Enqueue(b);
            var actualA = queue.Dequeue();
            var actualB = queue.Dequeue();

            // //-- Assert
            Assert.AreEqual(a, actualA);
            Assert.AreEqual(b, actualB);
        }
    }
}