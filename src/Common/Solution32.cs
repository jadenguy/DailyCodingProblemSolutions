using System;
using Common.Node.Graph;

namespace Common
{
    public static class Solution32
    {
        public static bool FindArbitrageBellmanFord(decimal[,] array)
        {
            var ret = true;
            var table = array.ToExchangeTable();
            var graph = table.ToWeightedGraph();
            return ret;
        }
        public static WeightedGraphNode ToWeightedGraph(this Forex.CurrencyExchangeTable table)
        {
            var root = new WeightedGraphNode("root");
            return root;
        }
    }
}