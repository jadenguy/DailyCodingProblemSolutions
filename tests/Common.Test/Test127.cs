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
            a.BreadthFirstSearch().Select(n => n.Value).Print("->").WriteHost("First");
            b.BreadthFirstSearch().Select(n => n.Value).Print("->").WriteHost("Second");
            sum.BreadthFirstSearch().Select(n => n.Value).Print("->").WriteHost("Wanted");

            //-- Act
            var actual = Solution127.AddReverseDigitLinkedList(a, b);
            actual.BreadthFirstSearch().Select(n => n.Value).Print("->").WriteHost("Actual Sum");

            // //-- Assert
            Assert.AreEqual(expected.BreadthFirstSearch().Select(n => n.Value), actual.BreadthFirstSearch().Select(n => n.Value));
        }
        class Cases : IEnumerable
        {
            const int testCount = 5;
            public IEnumerator GetEnumerator()
            {
                var rand = new System.Random(127);
                yield return CreateTests(99, 25);
                for (int i = 0; i < testCount; i++)
                {
                    yield return CreateTests(rand.Next(int.MaxValue / 2), rand.Next(int.MaxValue / 2));
                    yield return CreateTests(rand.Next(int.MaxValue / 2), rand.Next(9));
                }
            }
            private static object[] CreateTests(int aInt, int bInt)
            {
                var a = new SinglyLinkedListNode<int>(aInt.ToString().Reverse().Select(n => n - 48));
                var b = new SinglyLinkedListNode<int>(bInt.ToString().Reverse().Select(n => n - 48));
                var sum = new SinglyLinkedListNode<int>((aInt + bInt).ToString().Reverse().Select(n => n - 48));
                return new object[] { a, b, sum };
            }
        }
    }
}