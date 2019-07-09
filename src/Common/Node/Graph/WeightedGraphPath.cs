namespace Common.Node.Graph
{
    public class WeightedGraphPath : GraphPath<WeightedGraphNode>
    {
        public decimal Weight;
        public WeightedGraphPath() { }
        public WeightedGraphPath(WeightedGraphNode nextNode, decimal weight = 0)
        {
            Next = nextNode;
            Weight = weight;
        }
        public override string ToString() => $"{Next.Name} at {Weight}";
    }
}