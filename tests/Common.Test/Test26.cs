// Given a singly linked list and an integer k, remove the kth last element from the list. k is guaranteed to be smaller than the length of the list.
// The list is very long, so making more than one pass is prohibitively expensive.
// Do this in constant space and in one pass.

using NUnit.Framework;
using System.Linq;
using Common.Node;

namespace Common.Test
{
    public class Test26
    {
        LinkedListNode list;
        [SetUp]
        public void Setup()
        {
            var list = Common.Node.LinkedListNode.GenerateLinkedListNode(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        }

        [Test]
        [TestCase(1, 20)]
        public void Problem26(int wanted, int value)
        {
            //-- Arrange
            var expectedNValue = value;
            var expectedListLength = 19;

            //-- Act
            Solution26.RemoveNthLastElement(list, wanted);
            var array = list.Traverse().ToArray();
            var actualNValue = array.GetValue(array.Length - wanted - 1);
            var ActualListLength = array.Length;

            //-- Assert
            Assert.AreEqual(expectedNValue, actualNValue);
            Assert.AreEqual(expectedListLength, ActualListLength);
        }
    }
}