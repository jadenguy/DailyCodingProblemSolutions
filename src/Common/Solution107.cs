using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public static class Solution107
    {
        public static string PrintTree(BinaryNode<int> node)
        {
            var ret = string.Empty;
            var levels = new Dictionary<int, List<BinaryNode<int>>>() { };
            levels.Add(0, new List<BinaryNode<int>>() { node });
            for (int i = 0; i < levels.Count; i++)
            {
                var current = levels[i];
                var z = current.SelectMany(n => n.Children()).ToList();
                if (z.Count > 0)
                {
                    levels.Add(i + 1, new List<BinaryNode<int>>(z));
                }
            }
            var list = levels.ToList();
            return ret;
        }
    }
}