using System.Collections.Generic;

namespace Common.Node.Graph
{
    public class WeightedGraphNode : GraphNode<WeightedGraphNode>
    {
        public string Name;
        public WeightedGraphNode(string name)
        {
            this.Name = name;
            Paths = new List<WeightedGraphPath>();
        }
        public void ConnectTo(WeightedGraphNode nextNode, int weight)
        {
            ((List<WeightedGraphPath>)Paths).Add(new WeightedGraphPath(nextNode, weight));
        }
    }
}