using System;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution036

    {
        public static BinarySearchNode<int> SecondLargestNodeInTree(BinarySearchNode<int> root)
        {
            var array = root.InOrder().ToArray();
            return (BinarySearchNode<int>)array[array.Length - 2];
        }
    }
}