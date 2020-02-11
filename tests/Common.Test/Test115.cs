// Given two non-empty binary trees s and t, check whether tree t has exactly the same structure and node values with a subtree of s. A subtree of s is a tree consists of a node in s and all of this node's descendants. The tree s could also be considered as a subtree of itself.

using System.Collections;
using System.Linq;
using Common.Extensions;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test115
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        // [TestCaseSource(typeof(CasesTwo))]
        public void Problem115(BinaryNode<int> a, BinaryNode<int> b, bool result)
        {
            //-- Arrange
            var expected = result;
            System.Func<BinaryNode<int>, string> textFunc = n => n.Value.ToString();
            WriterExtension.WriteHost("Starting");
            a?.Print(textFunc).WriteHost();
            b?.Print(textFunc).WriteHost();
            expected.WriteHost(nameof(expected));

            //-- Act
            var actual = Solution115.BSTContainsBST(a, b);
            actual.WriteHost("IsPartOrWhole");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var rand = new System.Random(115);
                var a = ArbitraryTreeBinaryNode.GenerateArbitaryBinaryTreeNode(rand.Next());
                yield return new object[] { a, a, true };
                var b = ArbitraryTreeBinaryNode.GenerateArbitaryBinaryTreeNode(rand.Next());
                yield return new object[] { a, b, false };
                var c = a.Children().FirstOrDefault();
                yield return new object[] { a, c, true };
            }
        }
    }
}
