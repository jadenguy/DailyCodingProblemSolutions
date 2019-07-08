using System.Collections.Generic;

namespace Common.Node.Graph
{
    public class WeightedGraphNode : GraphNode<WeightedGraphNode>
    {
        public string Name;
        public WeightedGraphNode(string name)
        {
            this.Name = name;
            Paths = new List<GraphPath<WeightedGraphNode>>();
        }
        public void ConnectTo(WeightedGraphNode nextNode, int weight)
        {
            ((List<GraphPath<WeightedGraphNode>>)Paths).Add(new WeightedGraphPath(nextNode, weight));
        }
    }
}