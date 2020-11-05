// Given the head of a singly linked list, swap every two nodes and return its head.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test145
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases145))]
        public void Problem145(int[] array, int[] expectedArray)
        {
            //-- Assert
            var node = new Node.SinglyLinkedListNode<int>(array);
            var expected = new Node.SinglyLinkedListNode<int>(expectedArray);

            //-- Arrange
            var expectedList = expected.BreadthFirstSearch().Select(n => n.Value);
            var actual = Solution145.FlipEveryTwo(node);
            var actualList = actual.BreadthFirstSearch().Select(n => n.Value);

            //-- Act
            Assert.AreEqual(expectedList, actualList, "series mismatch");
        }
    }
    public class Cases145 : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var expected = new[] { 1, 2, 3 };
            var array = new[] { 2, 1, 3 };
            yield return new object[] { array, expected };
            expected = new[] { 1, 2 };
            array = new[] { 2, 1 };
            yield return new object[] { array, expected };
            expected = new[] { 1 };
            array = new[] { 1 };
            yield return new object[] { array, expected };
        }
    }
}