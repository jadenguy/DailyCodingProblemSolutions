using System;
using System.Collections.Generic;

namespace Common.Node.Graph
{
    public class WeightedGraphNode : GraphNode<WeightedGraphNode>, IEquatable<WeightedGraphNode>
    {
        public string Name;
        public WeightedGraphNode(string name)
        {
            this.Name = name;
            Paths = new List<GraphPath<WeightedGraphNode>>();
        }
        public void ConnectTo(WeightedGraphNode nextNode, decimal weight)
        {
            ((List<GraphPath<WeightedGraphNode>>)Paths).Add(new WeightedGraphPath(nextNode, weight));
        }
        public bool Equals(WeightedGraphNode other) => this.Name.Equals(other.Name);
        public override string ToString() => Name;
    }
}
