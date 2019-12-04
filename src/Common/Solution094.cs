using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution094
    {
        public static int LongestPathSum(BinaryNode<int> node, bool checkNegative = true)
        {
            var ret = 0;
            if (node is null)
            { throw new System.Exception("null node checked"); }
            else
            {
                GraphNode graph = CreateGraph(node)
            }
            return ret;
        }
        private static GraphNode CreateGraph(BinaryNode<int> node)
        {
            throw new NotImplementedException();
        }
    }
}