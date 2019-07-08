namespace Common.Node.Graph
{
    public class WeightedGraphPath : GraphPath<WeightedGraphNode>
    {
        public decimal Weight;
        public WeightedGraphPath() { }
        public WeightedGraphPath(WeightedGraphNode nextNode, int weight = 0)
        {
            Next = nextNode;
            Weight = weight;
        }
    }
}