using System;
using Common.Node;

namespace Common
{
    public static class Solution008

    {
        public static int CountUnival(BinaryNode<string> root, out bool isUnival)
        {
            var ret = 0;
            isUnival = true;
            foreach (BinaryNode<string> child in root.Children())
            {
                ret += CountUnival(child, out var subUnival);
                isUnival &= subUnival && child.Data == root.Data;
            }
            if (isUnival) { ret++; }
            return ret;
        }
    }
}