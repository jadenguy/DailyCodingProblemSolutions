using System;
using Common.Node;

namespace Common
{
    public static class Solution8
    {
        public static int CountUnival(BinaryNode<string> root, out bool isUnival)
        {
            var ret = 0;
            isUnival = true;
            foreach (BinaryNode<string> child in root.Children())
            {
                ret += CountUnival(child, out var subUnival);
                isUnival &= subUnival && child.Value == root.Value;
            }
            if (isUnival) { ret++; }
            return ret;
        }
    }
}