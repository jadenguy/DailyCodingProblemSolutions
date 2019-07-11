using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Node
{
    public class GraphNode : Node<GraphNode>, IEquatable<GraphNode>

    {
        public Dictionary<GraphNode, double> Paths = new Dictionary<GraphNode, double>();
        public string Id { get; set; }
        public GraphNode(string id)
        {
            Id = id;
        }
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
        public bool Equals(GraphNode other) => this.Id == other.Id;
        public void ConnectTo(GraphNode node, double weight) { Paths.Add(node, weight); }
        public override string ToString() => Id;
    }
}