// Given a node in a binary search tree, return the next bigger element, also known as the inorder successor.
// For example, the inorder successor of 22 is 30.
//    10
//   /  \
//  5    30
//      /  \
//    22    35
// You can assume each node has a parent pointer.

using System.Collections;
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

            //-- Act
            var actual = Solution133.FindSuccessor(leaf);

            //-- Assert
            Assert.AreSame(expected, actual);
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
                yield return new object[] { root.Right.Left, root.Right };
                root = v(1);
                root.Right = v(2);
                root.Right.Right = v(3);
                root.Right.Right.Right = v(10);
                root.Right.Right.Right.Left = v(4);
                root.Right.Right.Right.Left.Right = v(5);
                root.Right.Right.Right.Right = v(11);
                yield return new object[] { root.Right.Right.Right.Left, root.Right.Right.Right.Left.Right };
            }
            private static ParentAwareBSTNode<int> v(int value) => new ParentAwareBSTNode<int>(value);
        }
    }
}