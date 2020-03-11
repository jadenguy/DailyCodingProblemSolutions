﻿// Given a binary tree, find a minimum path sum from root to a leaf.
// For example, the minimum path in this tree is [10, 5, 1, -1], which has sum 15.
//   10
//  /  \
// 5    5
//  \     \
//    2    1
//        /
//      -1

using System.Collections;
using System.Linq;
using Common.Extensions;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test135
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem135(BinaryNode<int> root, int minPathSum)
        {
            //-- Arrange
            var expected = minPathSum;
            root.Print().WriteHost("Tree", true, true);
            root.InOrder().Select(v => v.Value).Print(",").WriteHost("InOrder");
            minPathSum.WriteHost("Wanted Leaf Path Sum");

            //-- Act
            var actual = Solution135.CheapestPath(root);
            actual.WriteHost("Actual");

            //-- Assert
            Assert.AreSame(expected, actual);
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                // 0
                var root = n(10);
                yield return new object[] { root, 10 };
            }
            private static BinaryNode<int> n(int value) => new BinaryNode<int>(value);
        }
    }
}