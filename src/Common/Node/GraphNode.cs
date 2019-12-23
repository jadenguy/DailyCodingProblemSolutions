using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common.Node
{
    public class GraphNode : Node<GraphNode>, IEquatable<GraphNode>

    {
        public Dictionary<GraphNode, double> Paths = new Dictionary<GraphNode, double>();
        public string Name { get; set; }
        public GraphNode(string id) { Name = id; }
        public override IEnumerable<GraphNode> Children() => Paths.Keys.Select(p => p);
        public override IEnumerable<GraphNode> BreadthFirstSearch()
        {
            var list = new Queue<GraphNode>() { };
            var everVisited = new List<GraphNode>() { };
            list.Enqueue((GraphNode)this);
            do
            {
                var current = list.Dequeue();
                if (!everVisited.Contains(current))
                {
                    yield return current;
                    everVisited.Add(current);
                    foreach (var child in current.Children()) { list.Enqueue(child); }
                }
            } while (list.Count != 0);
        }
        [System.Diagnostics.DebuggerStepThrough] public bool Equals(GraphNode other) => this.Name == other.Name;
        public void ConnectTo(GraphNode node, double weight = 1) { Paths[node] = weight; }
        [System.Diagnostics.DebuggerStepThrough] public override string ToString() => Name;
        public bool ContainsNegativeLoop(int precision = 0) => BellmanFord(precision, true).Any(v => double.IsNegativeInfinity(v.Value));
        public Dictionary<GraphNode, double> BellmanFord(double precision = 0, bool detectNegativeCycles = false, bool propagateNegative = false, Dictionary<GraphNode, double> bellmanFordChart = null)
        {
            bellmanFordChart = bellmanFordChart ?? this.BreadthFirstSearch().ToDictionary(k => k, v => double.PositiveInfinity);
            bellmanFordChart[this] = 0d;
            var connectorList = bellmanFordChart.Keys.SelectMany(g => g.Paths.Select(x => new { Start = g, End = x.Key, Weight = x.Value })).Random().ToArray();
            int i = 1;
            var same = true;
            // System.Diagnostics.Debug.WriteLine(connectorList.Print());
            do
            {
                var old = bellmanFordChart.ToDictionary(k => k.Key, v => v.Value);
                foreach (var connector in connectorList)
                {
                    var sourceDistance = bellmanFordChart[connector.Start];
                    double currentDistance = bellmanFordChart[connector.End];
                    double pathWeight = connector.Weight;
                    double potentialDistance = sourceDistance + pathWeight;
                    if (potentialDistance + precision < currentDistance)
                    {
                        if (detectNegativeCycles && i >= bellmanFordChart.Count) { bellmanFordChart[connector.End] = double.NegativeInfinity; }
                        else { bellmanFordChart[connector.End] = potentialDistance; }
                    }
                }
                i++;
                // System.Diagnostics.Debug.WriteLine(bellmanFordChart.Print());
                // System.Diagnostics.Debug.WriteLine("");
                same = bellmanFordChart.Keys.All(item => old[item] == bellmanFordChart[item]);
            } while (!same && i < bellmanFordChart.Count || (detectNegativeCycles && i == bellmanFordChart.Count));
            return bellmanFordChart;
        }
    }
}