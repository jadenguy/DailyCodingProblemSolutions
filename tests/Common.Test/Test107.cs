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
        public void Problem107(BinaryNode<string> node, string result)
        {
            //-- Arrange
            var expected = result;
            System.Console.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine(node?.Print(n => n.Value.ToString()));
            System.Diagnostics.Debug.WriteLine(node?.Print(n => n.Value.ToString()));
            System.Console.WriteLine(expected);
            System.Diagnostics.Debug.WriteLine(expected);

            //-- Act
            var actual = Solution107.PrintBFS(node);
            System.Console.WriteLine(actual);
            System.Diagnostics.Debug.WriteLine(actual);

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
            private const int TestCount = 10;
            private const int Seed = 0;
            public IEnumerator GetEnumerator()
            {
                BinaryNode<string> root = null;
                String result = null;
                
                // by using a constant seed here, we can better use automatic testing
                // the reason is that the name of the test changes based on the text of the object
                var rand = new Random(Seed);
                for (int i = 0; i < TestCount; i++)
                {
                    var enumerable = Enumerable.Range(0, TestCount).Select(r => rand.Next().ToString("X8")).Distinct();
                    root = BinarySearchNode<string>.GenerateBinarySearchNode(enumerable);
                    result = root.BreadthFirstSearch().Select(n => n.Value).Print(", ");
                    yield return new object[] { root, result };
                }
            }
        }
    }
}
