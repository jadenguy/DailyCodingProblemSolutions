// Given the head of a singly linked list, reverse it in-place.

using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace Common.Test
{
    public class Test073
    {
        private const int Count = 10;

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown(){}
        [Test]
        public void Problem073()
        {
            //-- Arrange
            var expected = Enumerable.Range(1, Count).Select(n => Count - n);
            var x = new Node.LinkedListNode(Enumerable.Range(0, Count));

            //-- Act
            var actual = Solution073.ReverseLinkedList(x).BreadthFirstSearch();

            //-- Assert
            Assert.AreEqual(expected, actual.Select(n => n.Value));
        }
    }
}