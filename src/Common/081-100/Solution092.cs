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
            foreach (var child in scheduleRules)
            {
                foreach (var parent in child.Value)
                {
                    try
                    {
                        var childNode = graphArray.Where(g => g.Name == child.Key).FirstOrDefault();
                        var parentNode = graphArray.Where(g => g.Name == parent).FirstOrDefault();
                        parentNode.ConnectTo(childNode, -1);
                    }
                    catch (Exception) { return null; }
                }
            }
            var bellmanFordChart = graphArray[0].BellmanFord(0, true, true);
            var chainStarts = bellmanFordChart.Where(v => v.Value == double.PositiveInfinity);
            while (chainStarts.Any())
            {
                chainStarts.First().Key.BellmanFord(0, true, true, bellmanFordChart);
                var isLoop = bellmanFordChart.Any(v => double.IsNegativeInfinity(v.Value));
                if (isLoop) { return null; }
            }
            return bellmanFordChart.OrderByDescending(v => v.Value).ThenBy(k => k.Key.Name).Select(k => k.Key.Name);
        }
    }
}
