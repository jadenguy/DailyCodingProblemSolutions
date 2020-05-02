// Given k sorted singly linked lists, write a function to merge all the lists into one sorted singly linked list.


using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test078
    {
        [SetUp]
        public void Setup()
        {
            var list = new List<int[]>();
            var result = new List<int>();
            var rand = Rand.NewRandom(078);
            var listCount = 5;
            var elementCount = 5;
            for (int i = 0; i < listCount; i++)
            {
                var tempList = Enumerable.Range(0, elementCount).Select(x => rand.Next()).ToArray();
                list.Add(tempList.OrderBy(x => x).ToArray());
                result.AddRange(tempList);
            }
            testCase = list.ToArray();
            testResult = result.OrderBy(x => x).ToArray();
        }
        // [TearDown] public void TearDown(){}
        int[][] testCase;
        int[] testResult;

        [Test]
        public void Problem078()
        {
            //-- Arrange
            var nodes = testCase.Select(l => new SinglyLinkedListNode<int>(l));
            var expected = testResult;
            System.Diagnostics.Debug.WriteLine(Common.Extensions.CollectionExtensions.Print(expected));

            //-- Act
            var actual = Solution078.MergeSortedLinkedList(nodes).Select(v => v.Value);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}