// Given a binary tree where all nodes are either 0 or 1, prune the tree so that subtrees containing all 0s are removed.
// For example, given the following tree:
//    0
//   / \
//  1   0
//     / \
//    1   0
//   / \
//  0   0
// should be pruned to:
//    0
//   / \
//  1   0
//     /
//    1

using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;
using Common.Node;
using System.Collections;

namespace Common.Test
{
    public class Test146
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases146))]
        public void Problem146(BinaryNode<int> input, BinaryNode<int> output)
        {
            //-- Assert
            var expected = output;

            output.Print(n => n.Data).WriteHost("Wanted");
            input.Print(n => n.Data).WriteHost("Input");

            //-- Arrange
            var actual = Solution146.Prune(input);
            actual.Print(n => n.Data).WriteHost("Results");

            //-- Act
            Assert.AreEqual(expected, actual, "trees don't match");
        }
        class Cases146 : IEnumerable
        {
            static BinaryNode<int> n(int data) => new BinaryNode<int>(data);
            public IEnumerator GetEnumerator()
            {
                BinaryNode<int> normal, clean;

                // 1
                normal = n(1);
                normal.Left = n(1);
                normal.Right = n(0);

                clean = n(1);
                clean.Left = n(1);

                yield return new object[] { normal, clean };


                // 0
                normal = n(0);
                normal.Left = n(1);
                normal.Right = n(0);
                normal.Right.Left = n(1);
                normal.Right.Right = n(0);
                normal.Right.Left.Left = n(0);
                normal.Right.Left.Right = n(0);

                clean = n(0);
                clean.Left = n(1);
                clean.Right = n(0);
                clean.Right.Left = n(1);

                yield return new object[] { normal, clean };
            }
        }
    }
}
