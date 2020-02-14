using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common.Node
{
    public class GraphNode<T> : Node<GraphNode<T>>, IEquatable<GraphNode<T>> where T : IEquatable<T>

    {
        public Dictionary<GraphNode<T>, double> Paths = new Dictionary<GraphNode<T>, double>();
        public string Name { get; set; }
        public T Value { get; private set; }
        public GraphNode(T value)
        {
            Name = value.ToString();
            Value = value;
        }
        public GraphNode(T value, string name)
        {
            Name = name;
            Value = value;
        }
        public override IEnumerable<GraphNode<T>> Children() => Paths.Keys.Select(p => p);
        public override IEnumerable<GraphNode<T>> BreadthFirstSearch()
        {
            var list = new Queue<GraphNode<T>>() { };
            var everVisited = new List<GraphNode<T>>() { };
            list.Enqueue(this);
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
        [System.Diagnostics.DebuggerStepThrough] public bool Equals(GraphNode<T> other) => Name == other.Name && Value.Equals(other.Value);
        [System.Diagnostics.DebuggerStepThrough] public void ConnectTo(GraphNode<T> node, double weight = 1) { Paths[node] = weight; }
        [System.Diagnostics.DebuggerStepThrough] public override string ToString() => Name;
        public bool ContainsNegativeLoop(int precision = 0) => BellmanFord(precision, true).Any(v => double.IsNegativeInfinity(v.Value));
        public Dictionary<GraphNode<T>, double> BellmanFord(double precision = 0, bool detectNegativeCycles = false, bool propagateNegative = false, Dictionary<GraphNode<T>, double> bellmanFordChart = null)
        {
            bellmanFordChart = bellmanFordChart ?? this.BreadthFirstSearch().ToDictionary(k => k, v => double.PositiveInfinity);
            bellmanFordChart[this] = 0d;
            var connectors = bellmanFordChart.Keys.SelectMany(g => g.Paths.Select(x => new { Start = g, End = x.Key, Weight = x.Value }));
            var connectorArray = connectors.Shuffle().ToArray();
            int i = 1;
            var same = true;
            // System.Diagnostics.Debug.WriteLine(connectorList.Print());
            do
            {
                var old = bellmanFordChart.ToDictionary(k => k.Key, v => v.Value);
                foreach (var connector in connectorArray)
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