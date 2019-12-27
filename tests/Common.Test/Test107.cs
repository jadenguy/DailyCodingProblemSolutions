// Print the nodes in a binary tree level-wise. For example, the following should print 1, 2, 3, 4, 5.
//   1
//  / \
// 2   3
//    / \
//   4   5

using System;
using System.Collections;
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
        public void Problem107(BinaryNode<string> node, string result)
        {
            //-- Arrange
            var expected = result;
            System.Console.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine(expected);
            System.Diagnostics.Debug.WriteLine(expected);

            //-- Act
            var actual = Solution107.PrintTree(node);
            System.Console.WriteLine(actual);
            System.Diagnostics.Debug.WriteLine(actual);

            // //-- Assert
            // Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            private static BinaryNode<string> n(object data) => new BinaryNode<string>(data.ToString());
            public IEnumerator GetEnumerator()
            {
                BinaryNode<string> root;
                String result;
                root = n("ONE");
                root.Left = n("TWO");
                root.Right = n("THREE");
                root.Right.Left = n("FOUR");
                root.Right.Right = n("FIVE");
                result = "  1\n / \\\n2   3\n   / \\\n  4   5\n";
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
                result = "  1\n / \\\n2   3\n   / \\\n  4   5\n / \\\n6   7\n   / \\\n  8   9\n";
                yield return new object[] { root, result };
            }
        }
    }
}
