// For example, given A = 3 -> 7 -> 8 -> 10 and B = 99 -> 1 -> 8 -> 10, return the node with value 8.
// In this example, assume nodes with the same value are the exact same node objects.
// Do this in O(M + N) time (where M and N are the lengths of the lists) and constant space.
using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test020
    {
        public List<LinkedListNode> lll = new List<LinkedListNode>();

        [SetUp]
        public void Setup()
        {
            lll.Add(new LinkedListNode(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
            lll[0][8] = new LinkedListNode(9);
            lll.Add(new LinkedListNode(new int[] { 99, 98 }));
            lll[1][2] = lll[0][2];
            lll.Add(new LinkedListNode(new int[] { 97, 96, 95, 94 }));
            lll[2][4] = lll[0][4];
            lll.Add(new LinkedListNode(new int[] { 93, 92, 91 }));
            lll[3][3] = lll[0][0];

        }
        [Test]
        [TestCase(0, 1, 3)]
        [TestCase(0, 2, 5)]
        [TestCase(0, 3, 1)]
        public void Problem020(int aListIndex, int bListIndex, int common)
        {
            //-- Arrange
            var a = lll[aListIndex];
            System.Diagnostics.Debug.WriteLine(a.Print());
            var b = lll[bListIndex];
            System.Diagnostics.Debug.WriteLine(b.Print());
            var expected = common;

            //-- Act
            var actual = Solution020.FindCommonNode(a, b);

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}