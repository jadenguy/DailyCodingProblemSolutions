using System;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution094
    {
        public static int MaxPathSum(BinaryNode<int> node)
        {
            if (node == null) { return 0; }
            else
            {
                var enumerable = node.Children().Select(n => MaxPathSum(n)).ToArray();
                var max = enumerable.OrderByDescending(v => v).FirstOrDefault();
                int maxCountingNode = node.Data + max;
                if (maxCountingNode > max) { return maxCountingNode; }
                else if (node.Data > max) { return node.Data; }
                else { return max; }
            }
        }
    }
}