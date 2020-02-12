// Given a binary tree, return the level of the tree with minimum sum.

using System.Collections;
using Common.Extensions;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test117
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem117(BinaryNode<int> node, int result)
        {
            //-- Arrange
            var expected = result;
            ("tree").WriteHost();
            node.Print(n => " " + n.Value.ToString()).WriteHost();
            expected.WriteHost("Expected");

            //-- Act
            var actual = Solution117.MinimumSum(node);
            actual.WriteHost("Actual");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            private static BinaryNode<int> n(int data) => new BinaryNode<int>(data);
            public IEnumerator GetEnumerator()
            {
                BinaryNode<int> root;
                BinaryNode<int> current;
                int result;

                // 0
                root = n(1);
                root.Left = n(2);
                root.Right = n(3);
                root.Right.Left = n(4);
                root.Right.Right = n(5);
                result = 0;
                yield return new object[] { root, result };

                // 1
                root = n(1);
                root.Left = n(2);
                root.Right = n(int.MinValue);
                root.Right.Left = n(4);
                root.Right.Right = n(5);
                result = 1;
                yield return new object[] { root, result };

                // 2
                root = n(0);
                current = root;
                const int nodeCount2 = 6;
                for (int i = 1; i <= nodeCount2; i++)
                {
                    current.Right = n(i);
                    current = current.Right;
                }
                result = 0;
                yield return new object[] { root, result };

                // 3
                root = n(0);
                current = root;
                const int nodeCount3 = 6;
                for (int i = 1; i <= nodeCount3; i++)
                {
                    current.Right = n(-i);
                    current = current.Right;
                }
                result = nodeCount3;
                yield return new object[] { root, result };

                // 4
                root = n(int.MaxValue);
                result = 0;
                yield return new object[] { root, result };
            }
        }
    }
}
