using System;
using Common.Node;

namespace Common
{
    public static class Solution133
    {
        public static ParentAwareBSTNode<int> FindSuccessor(ParentAwareBSTNode<int> leaf)
        {
            var current = leaf;
            while (current.Parent.Left == current && (current.Right?.Value ?? int.MinValue) < (current.Parent?.Value ?? int.MinValue)) { current = current.Parent; }
            return current;
        }
    }
}