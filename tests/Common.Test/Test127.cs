// Let's represent an integer in a linked list format by having each node represent a digit in the number. The nodes make up the number in reversed order.
// For example, the following linked list:
// 1 -> 2 -> 3 -> 4 -> 5
// is the number 54321.
// Given two linked lists in this format, return their sum in the same linked list format.
// For example, given
// 9 -> 9
// 5 -> 2
// return 124 (99 + 25) as:
// 4 -> 2 -> 1

using System.Collections;
using System.Linq;
using Common.Extensions;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test127
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem127(SinglyLinkedListNode<int> a, SinglyLinkedListNode<int> b, SinglyLinkedListNode<int> sum)
        {
            //-- Arrange
            var expected = sum;
            a.BreadthFirstSearch().Select(n => n.Value).Print(",").WriteHost();
            b.BreadthFirstSearch().Select(n => n.Value).Print(",").WriteHost();
            sum.BreadthFirstSearch().Select(n => n.Value).Print(",").WriteHost();

            //-- Act
            var actual = Solution127.AddReverseDigitLinkedList(a, b);
            actual.BreadthFirstSearch().Select(n => n.Value).Print(",").WriteHost();

            // //-- Assert
            Assert.AreEqual(a, b);
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                SinglyLinkedListNode<int> a, b, sum;
                CreateTests(99, 25, out a, out b, out sum);
                yield return new object[] { a, b, sum };
            }
            private static void CreateTests(int aInt, int bInt, out SinglyLinkedListNode<int> a, out SinglyLinkedListNode<int> b, out SinglyLinkedListNode<int> sum)
            {
                a = new SinglyLinkedListNode<int>(aInt.ToString().Reverse().Select(n => n - 48));
                b = new SinglyLinkedListNode<int>(bInt.ToString().Reverse().Select(n => n - 48));
                sum = new SinglyLinkedListNode<int>((aInt + bInt).ToString().Reverse().Select(n => n - 48));
            }
        }
    }
}