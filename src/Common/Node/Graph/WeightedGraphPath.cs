namespace Common.Node.Graph
{
    public class WeightedGraphPath : GraphPath<WeightedGraphNode>
    {
        public decimal Weight;

        public WeightedGraphPath(WeightedGraphNode nextNode, int weight)
        {
            Next = nextNode;
            Weight = weight;
        }
    }
}