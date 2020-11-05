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
        public void Problem145(int[] expectedArray, int[] actualArray)
        {
            //-- Assert
            var expected = new Node.SinglyLinkedListNode<int>(expectedArray);
            var node = new Node.SinglyLinkedListNode<int>(actualArray);

            //-- Arrange
            var expectedList = expected.BreadthFirstSearch().Select(n => n.Value).ToArray();
            var actual = Solution145.FlipEveryTwo(node);
            var actualList = actual.BreadthFirstSearch().Select(n => n.Value).ToArray();

            //-- Act
            Assert.AreEqual(expectedList, actualList, "series mismatch");
        }
        class Cases145 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                int[] expected, array;

                expected = new[] { 1 };
                array = new[] { 1 };
                yield return new object[] { array, expected };

                expected = new[] { 1, 2 };
                array = new[] { 2, 1 };
                yield return new object[] { array, expected };

                expected = new[] { 1, 2, 3 };
                array = new[] { 2, 1, 3 };
                yield return new object[] { array, expected };

                expected = Enumerable.Range(0, 4).Select(n => (new[] { funcA(n), funcB(n) })).SelectMany(a => a).ToArray();
                array = Enumerable.Range(0, 4).Select(n => new[] { funcB(n), funcA(n) }).SelectMany(a => a).ToArray();
                yield return new object[] { array, expected };


                expected = Enumerable.Range(0, 400).Select(n => (new[] { funcA(n), funcB(n) })).SelectMany(a => a).ToArray();
                array = Enumerable.Range(0, 400).Select(n => new[] { funcB(n), funcA(n) }).SelectMany(a => a).ToArray();
                yield return new object[] { array, expected };

                yield break;
            }
            static int funcA(int n) => 2 * n;

            static int funcB(int n) => 2 * n + 1;
        }
    }

}