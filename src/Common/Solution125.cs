using System;
using System.Linq;
using Common.Node;

namespace Common
{
    public static class Solution125
    {
        public static BinarySearchNode<int>[] FindSumPairs(BinarySearchNode<int> input, int k)
        {
            BinarySearchNode<int> left = input;
            BinarySearchNode<int> right = input;
            Func<BinarySearchNode<int>[]> current = () => new BinarySearchNode<int>[] { left, right };
            while (current().Sum(n => n.Value) != k)
            {

            }
            return left == right ? null : current();
        }
    }
}