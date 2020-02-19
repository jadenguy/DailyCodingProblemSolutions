using System.Collections.Generic;
using Common.Node;

namespace Common
{
    public static class Solution125
    {
        public static BinarySearchNode<int>[] FindSumPairs(BinarySearchNode<int> input, int k)
        {
            BinaryNode<int> a = input;
            BinaryNode<int> b = input;
            var q = new Queue<(BinaryNode<int> left, BinaryNode<int> right)>();
            if (input.Left != null) { q.Enqueue((input.Left, input)); }
            if (input.Right != null) { q.Enqueue((input, input.Right)); }
            do
            {
                (a, b) = q.Dequeue();
                int sum = a.Value + b.Value;
                var compare = k.CompareTo(sum);
                if (compare < 0)
                {
                    if (a.Left != null && a.Left != b) { q.Enqueue((a.Left, b)); }
                    if (b.Left != null && a != b.Left) { q.Enqueue((a, b.Left)); }
                }
                else if (compare > 0)
                {
                    if (a.Right != null && a.Right != b) { q.Enqueue((a.Right, b)); }
                    if (b.Right != null && a != b.Right) { q.Enqueue((a, b.Right)); }
                }
                else
                {
                    return new BinarySearchNode<int>[] { a as BinarySearchNode<int>, b as BinarySearchNode<int> };
                }
            } while (q.Count > 0);
            return null;
        }
    }
}