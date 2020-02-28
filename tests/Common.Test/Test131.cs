// Given the head to a singly linked list, where each node also has a “random” pointer that points to anywhere in the linked list, deep clone the list.

using System.Collections;
using System.Linq;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test131
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem131(SinglePlusRandomLinkedListNode<int> original, SinglePlusRandomLinkedListNode<int> clone)
        {
            //-- Arrange
            var expected = clone;
            original.Print().WriteHost("List", true, true);
            clone.Print().WriteHost("Copy", true, true);

            //-- Act
            var actual = original.Clone();
            actual.Print().WriteHost();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var rand = new System.Random(131);
                const int Count = 10;
                var numbers = Enumerable.Range(0, Count).Select(n => rand.Next()).ToArray();
                var links = Enumerable.Range(0, Count).Shuffle(rand.Next()).ToArray();
                var a = numbers.Select(n => new SinglePlusRandomLinkedListNode<int>(n)).ToArray();
                var b = numbers.Select(n => new SinglePlusRandomLinkedListNode<int>(n)).ToArray();
                for (int i = 1; i < Count; i++)
                {
                    a[i - 1].Next = a[i];
                    b[i - 1].Next = b[i];
                }
                yield return new object[] { a.First(), b.First() };
            }
        }
    }
}