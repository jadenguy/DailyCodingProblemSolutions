// Given the root of a binary search tree, and a target K, return two nodes in the tree whose sum equals K.
// For example, given the following tree and K of 20
//     10
//    /   \
//  5      15
//        /  \
//      11    16
// Return the nodes 5 and 15.

using System.Collections;
using System.Linq;
using Common.Extensions;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test125
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem125(BinarySearchNode<int> input, int k, BinarySearchNode<int>[] result)
        {
            //-- Arrange
            var expected = result.ToHashSet(n => n);
            input.Print(n => n.Value).WriteHost("Node", true, true);
            result.Print(",").WriteHost("Expected");

            //-- Act
            var actual = Solution125.FindSumPairs(input, k);
            actual.Print(",").WriteHost("Actual");

            // //-- Assert
            Assert.IsTrue(expected.SetEquals(actual));
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                BinarySearchNode<int> root;
                int sum;
                BinarySearchNode<int>[] pairs;
                int[] sequence = new int[] { 10, 5, 15, 11, 16 };
                root = BinarySearchNode<int>.GenerateBinarySearchNode(sequence);
                sum = 20;
                pairs = new BinarySearchNode<int>[] { root.Left as BinarySearchNode<int>, root.Right as BinarySearchNode<int> };
                yield return new object[] { root, sum, pairs };
            }
        }
    }
}