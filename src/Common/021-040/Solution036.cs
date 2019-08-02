using System;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution036

    {
        public static BinarySearchNode SecondLargestNodeInTree(BinarySearchNode root)
        {
            var array = root.InOrder().ToArray();
            return (BinarySearchNode)array[array.Length - 2];
        }
    }
}