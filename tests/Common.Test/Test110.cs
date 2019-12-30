// Given a binary tree, return all paths from the root to leaves.
// For example, given the tree:
//    1
//   / \
//  2   3
//     / \
//    4   5
// Return [[1, 2], [1, 3, 4], [1, 3, 5]].

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test110
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        // [TestCaseSource(typeof(CasesTwo))]
        public void Problem110(BinaryNode<int> node, int[][] result)
        {
            //-- Arrange
            var expected = result;
            PrintInputs(node, expected);

            //-- Act
            var actual = Solution110.EnumerateBranches(node).ToArray();
            PrintOutput(actual);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        private static void PrintOutput(IEnumerable<IEnumerable<int>> actual)
        {
            string paths = actual.Select(p => p.Print(",")).Print();
            System.Console.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine(paths);
            System.Diagnostics.Debug.WriteLine(paths);
        }
        private static void PrintInputs(BinaryNode<int> node, int[][] expected)
        {
            System.Console.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            var tree = node?.Print(n => n.Value.ToString());
            System.Console.WriteLine(tree);
            System.Diagnostics.Debug.WriteLine(tree);
            PrintOutput(expected);
        }
        private static BinaryNode<int> n(int data) => new BinaryNode<int>(data);
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                BinaryNode<int> root;
                BinaryNode<int> current;
                int[][] result;

                // 0
                root = n(1);
                root.Left = n(2);
                root.Right = n(3);
                root.Right.Left = n(4);
                root.Right.Right = n(5);
                result = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3, 4 }, new int[] { 1, 3, 5 } };
                yield return new object[] { root, result };

                // 1
                root = n(0);
                current = root;
                const int nodeCount = 6;
                for (int i = 1; i <= nodeCount; i++)
                {
                    current.Right = n(i);
                    current = current.Right;
                }
                result = new int[][] { Enumerable.Range(0, nodeCount + 1).ToArray() };
                yield return new object[] { root, result };
            }
        }
        // class CasesTwo : IEnumerable
        // {
        //     private const int TestCount = 10;
        //     private const int Seed = 0;
        //     public IEnumerator GetEnumerator()
        //     {
        //         BinaryNode<string> root = null;
        //         String result = null;
        //         // by using a constant seed here, we can better use automatic testing
        //         // the reason is that the name of the test changes based on the text of the object
        //         var rand = new Random(Seed);
        //         for (int i = 0; i < TestCount; i++)
        //         {
        //             var enumerable = Enumerable.Range(0, TestCount).Select(r => rand.Next().ToString("X8")).Distinct();
        //             root = BinarySearchNode<string>.GenerateBinarySearchNode(enumerable);
        //             result = root.BreadthFirstSearch().Select(n => n.Value).Print(", ");
        //             yield return new object[] { root, result };
        //         }
        //     }
        // }
    }
}
