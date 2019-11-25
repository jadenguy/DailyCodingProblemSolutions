using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution092
    {
        public static IEnumerable<string> Order(Dictionary<string, string[]> scheduleRules)
        {
            //put items with zero dependencies on the top
            var graphArray = scheduleRules.OrderBy(v => v.Value.Length).Distinct().Select(n => new GraphNode(n.Key)).ToArray();
            foreach (var rule in scheduleRules)
            {
                foreach (var connection in rule.Value)
                {
                    var parentNode = graphArray.Where(g => g.Id == rule.Key).First();
                    var childNode = graphArray.Where(g => g.Id == connection).First();
                    parentNode.ConnectTo(childNode, -1);
                }
            }
            var bellmanFordChart = graphArray.ToDictionary(k => k, v => double.PositiveInfinity);
            var chainStarts = bellmanFordChart.Where(v => v.Value == double.PositiveInfinity);
            while (chainStarts.Any())
            {
                bellmanFordChart[chainStarts.First().Key] = 0;
                bellmanFordChart.BellmanFord();
                var loopie = bellmanFordChart.ToDictionary(k => k.Key, v => v.Value);
                var noLoop = loopie.BellmanFord(0, true, true).All(v => !double.IsNegativeInfinity(v.Value));
                if (!noLoop) { return null; }
            }
            return bellmanFordChart.OrderBy(v => v.Value).Select(k => k.Key.Id);
        }
    }
}
