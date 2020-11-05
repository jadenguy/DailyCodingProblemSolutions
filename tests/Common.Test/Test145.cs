// Given the head of a singly linked list, swap every two nodes and return its head.

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test145
    {


        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem145()
        {
            //-- Assert
            var node = new Node.SinglyLinkedListNode<int>(new[] { 1, 2, 3, 4, 5 });
            var expected = new Node.SinglyLinkedListNode<int>(new[] { 2, 1, 4, 3, 5 });

            //-- Arrange
            var actual = Solution145.FlipEveryTwo(node);
            var actual1 = expected.BreadthFirstSearch().Select(n => n.Value);
            var expected1 = actual.BreadthFirstSearch().Select(n => n.Value);

            //-- Act
            Assert.AreEqual(expected1, actual1, "series mismatch");
        }
    }
}
