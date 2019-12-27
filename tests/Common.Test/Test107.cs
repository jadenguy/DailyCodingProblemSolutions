// Print the nodes in a binary tree level-wise. For example, the following should print 1, 2, 3, 4, 5.
//   1
//  / \
// 2   3
//    / \
//   4   5

using System;
using System.Collections;
using System.Linq;
using Common.Extensions;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test107
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        [TestCaseSource(typeof(CasesTwo))]
        public void Problem107<T>(BinaryNode<T> node, string result)
        {
            //-- Arrange
            var expected = result;
            System.Console.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine(expected);
            System.Diagnostics.Debug.WriteLine(expected);

            //-- Act
            var actual = Solution107.PrintBFS(node);
            System.Diagnostics.Debug.WriteLine(node.Print());
            System.Console.WriteLine(node.Print());
            // System.Console.WriteLine(actual);
            // System.Diagnostics.Debug.WriteLine(actual);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        private static BinaryNode<string> n(object data) => new BinaryNode<string>(data.ToString());
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                BinaryNode<string> root;
                String result;
                root = n("ONE");
                root.Left = n("TWO");
                root.Right = n("THREE");
                root.Right.Left = n("FOUR");
                root.Right.Right = n("FIVE");
                result = "ONE, TWO, THREE, FOUR, FIVE";
                yield return new object[] { root, result };

                // // 1
                root = n("ONE");
                root.Left = n("TWO");
                root.Right = n("THREE");
                root.Right.Left = n("FOUR");
                root.Right.Right = n("FIVE");
                root.Right.Left.Left = n("SIX");
                root.Right.Left.Right = n("SEVEN");
                root.Right.Left.Right.Left = n("EIGHT");
                root.Right.Left.Right.Right = n("NINE");
                result = "ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE";
                yield return new object[] { root, result };
            }
        }
        class CasesTwo : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                BinaryNode<int> root;
                String result;
                var rand = new Random();
                root = BinarySearchNode.GenerateBinarySearchNode(Enumerable.Range(0, 20).Select(r => rand.Next()));
                result = root.BreadthFirstSearch().Print(", ");
                yield return new object[] { root, result };
            }
        }
    }
}
