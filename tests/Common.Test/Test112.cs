// Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree. Assume that each node in the tree also has a pointer to its parent.
// According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).”

using System.Collections;
using Common.Node;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test112
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        // [TestCaseSource(typeof(CasesTwo))]
        public void Problem112(BinaryNode<int> root, BinaryNode<int> a, BinaryNode<int> b, BinaryNode<int> lca)
        {
            //-- Arrange
            var expected = lca;
            WriteInputs(root, a, b, expected);

            //-- Act
            var actual = Solution112.FindLowestCommonAncestor(root, a, b);
            actual.WriteHost("results");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        private static void WriteInputs(BinaryNode<int> node, BinaryNode<int> a, BinaryNode<int> b, BinaryNode<int> expected)
        {
            var tree = node?.Print(n => n.Value.ToString());
            tree.WriteHost("Tree");
            a.WriteHost("A");
            b.WriteHost("B");
            expected.WriteHost("LCA");
        }
        private static BinaryNode<int> n(int data) => new BinaryNode<int>(data);
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                BinaryNode<int> root;
                BinaryNode<int> a;
                BinaryNode<int> b;
                BinaryNode<int> result;

                root = n(1);
                root.Left = n(2);
                root.Right = n(3);
                root.Left.Left = n(4);
                root.Right.Left = n(5);
                root.Right.Right = n(6);
                root.Right.Left.Right = n(7);

                a = root.Right.Left;
                b = root.Right.Right;
                result = root.Right;
                yield return new object[] { root, a, b, result };

                a = root.Left;
                b = root.Right;
                result = root;
                yield return new object[] { root, a, b, result };

                a = root;
                b = root.Right;
                result = root;
                yield return new object[] { root, a, b, result };

                a = root.Right;
                b = root.Right;
                result = root.Right;
                yield return new object[] { root, a, b, result };

                a = root.Left.Left;
                b = root.Right.Left;
                result = root;
                yield return new object[] { root, a, b, result };
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