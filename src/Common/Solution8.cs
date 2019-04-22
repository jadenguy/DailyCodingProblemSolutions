using System;

namespace Common
{
    public static class Solution8
    {
        public static int CountUnival(BinaryNode root, out bool isUnival)
        {
            var ret = 0;
            isUnival = true;
            foreach (var child in root.Children())
            {
                ret += CountUnival(child, out var subUnival);
                isUnival &= subUnival && child.Value == root.Value;
            }
            if (isUnival) { ret++; }
            return ret;
        }
    }
}