// Given a node in a binary search tree, return the next bigger element, also known as the inorder successor.
// For example, the inorder successor of 22 is 30.
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
        public void Problem133(ParentAwareBSTNode<int> leaf, ParentAwareBSTNode<int> successor)
        {
            //-- Arrange
            var expected = successor;
            var root = FindRoot(leaf);
            root.Print().WriteHost("Tree", true, true);
            root.InOrder().Select(v => v.Value).Print(",").WriteHost("InOrder");
            leaf.WriteHost("Leaf");
            successor.WriteHost("Wanted Successor");

            //-- Act
            var actual = Solution133.FindSuccessor(leaf);
            actual.Value.WriteHost("Actual");

            //-- Assert
            Assert.AreSame(expected, actual);
        }

        private static ParentAwareBSTNode<int> FindRoot(ParentAwareBSTNode<int> leaf)
        {
            var root = leaf;
            while (root.Parent != null) { root = root.Parent; }

            return root;
        }

        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var root = v(10);
                root.Left = v(5);
                root.Right = v(30);
                root.Right.Left = v(22);
                root.Right.Right = v(35);
                foreach (var test in WriteTests(root)) { yield return test; }

                root = v(1);
                root.Right = v(2);
                root.Right.Right = v(3);
                root.Right.Right.Right = v(7);
                root.Right.Right.Right.Left = v(5);
                root.Right.Right.Right.Left.Left = v(4);
                root.Right.Right.Right.Left.Right = v(6);
                root.Right.Right.Right.Right = v(8);
                foreach (var test in WriteTests(root)) { yield return test; }
                // var g = ParentAwareBSTNode<int>.GenerateBinarySearchNode(Enumerable.Range(0, 10).Shuffle(133));
            }
            private static IEnumerable<object[]> WriteTests(ParentAwareBSTNode<int> root)
            {
                var list = root.InOrder().ToArray();
                for (int i = 0; i < list.Length - 1; i++)
                {
                    yield return new object[] { list[i], list[i + 1] };
                }
            }
            private static ParentAwareBSTNode<int> v(int value) => new ParentAwareBSTNode<int>(value);
        }
    }
}