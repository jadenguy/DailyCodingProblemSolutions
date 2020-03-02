// Given the head to a singly linked list, where each node also has a “random” pointer that points to anywhere in the linked list, deep clone the list.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;
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
            original.BreadthFirstSearch().Print("->").WriteHost("List");
            expected.BreadthFirstSearch().Print("->").WriteHost("Copy");

            //-- Act
            var actual = original.DeepClone();
            actual.BreadthFirstSearch().Print("->").WriteHost("Deep Clone");
            var comp = new SinglePlusLinkComparer<int>();

            // //-- Assert
            Assert.IsTrue(explode(expected).SequenceEqual(explode(actual)));
        }
        private static IEnumerable<(int, string, int?, string, int?, string)> explode(SinglePlusRandomLinkedListNode<int> expected)
            => expected.BreadthFirstSearch().Select(x => (SinglePlusRandomLinkedListNode<int>)x).ToArray().Select(l => (l.Value, l.Name, l.Next?.Value, l.Next?.Name, l.Other?.Value, l.Other?.Name));
        class Cases : IEnumerable
        {
            const int Length = 10;
            private const int Seed = 131;
            public IEnumerator GetEnumerator()
            {
                var rand = new System.Random(Seed);
                var numbers = Enumerable.Range(0, Length).Select(n => rand.Next()).ToArray();
                var links = Enumerable.Range(0, Length).Shuffle(rand.Next()).ToArray();
                yield return new object[] { makeList(Length, numbers, links), makeList(Length, numbers, links) };
            }
            private static SinglePlusRandomLinkedListNode<int> makeList(int Count, int[] numbers, int[] links)
            {
                var array = numbers.Select(n => new SinglePlusRandomLinkedListNode<int>(n)).ToArray();
                for (int i = 1; i < Count; i++)
                {
                    int current = i - 1;
                    int next = i;
                    int other = links[next];
                    array[current].Other = array[other];
                    array[current].Next = array[next];
                }
                return array.First();
            }
        }
    }
}