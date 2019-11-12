using System;
using System.Linq;
using Common.Node;
using Common.Extensions;
using System.Collections.Generic;

namespace Common
{
    public class Solution080
    {
        public static object Evaluate(BinaryNode<string> node)
        {
            var nextLevel = node.Children();
            IEnumerable<BinaryNode<string>> previousLevel = new BinaryNode<string>[] {node};
            while (!nextLevel.IsNullOrEmpty())
            {
                previousLevel = nextLevel;
                nextLevel = nextLevel.SelectMany(n => n.Children());
            }
            return previousLevel.FirstOrDefault();
        }
    }
}