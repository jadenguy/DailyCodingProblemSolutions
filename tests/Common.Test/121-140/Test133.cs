// Given a node in a binary search tree, return the next bigger element, also known as the in order successor.
// For example, the in order successor of 22 is 30.
//    10
//   /  \
//  5    30
//      /  \
//    22    35
// You can assume each node has a parent pointer.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test133
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem133(BinaryNode<int> leaf, BinaryNode<int> successor)
        {
            //-- Arrange
            var expected = successor;
            var root = FindRoot(leaf);
            root.Print().WriteHost("Tree", true, true);
            root.InOrder().Select(v => v.Value).Print(",").WriteHost("InOrder");
            leaf.WriteHost("Leaf");
            WriteNodeValue(successor, "Wanted Successor");

            //-- Act
            var actual = Solution133.FindSuccessor(leaf);
            WriteNodeValue(actual, "Actual");

            //-- Assert
            Assert.AreSame(expected, actual);
        }
        private static void WriteNodeValue(BinaryNode<int> actual, string header) => (actual?.Value.ToString() ?? "[null]").WriteHost(header);
        private static BinaryNode<int> FindRoot(BinaryNode<int> leaf)
        {
            var root = leaf;
            while (root.Parent != null) { root = root.Parent; }

            return root;
        }

        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                // 0
                var root = v(10);
                root.Left = v(5);
                root.Right = v(30);
                root.Right.Left = v(22);
                root.Right.Right = v(35);
                foreach (var test in WriteTests(root)) { yield return test; }

                // 1    
                root = BinarySearchNode<int>.GenerateBinarySearchNode(Enumerable.Range(0, 10).Shuffle(133));
                foreach (var test in WriteTests(root)) { yield return test; }
            }
            private static IEnumerable<object[]> WriteTests(BinaryNode<int> root)
            {
                var list = root.InOrder().ToArray();
                for (int i = 0; i < list.Length; i++)
                {
                    yield return new object[] { list.ElementAtOrDefault(i), list.ElementAtOrDefault(i + 1) };
                }
            }
            private static BinaryNode<int> v(int value) => new BinaryNode<int>(value);
        }
    }
}