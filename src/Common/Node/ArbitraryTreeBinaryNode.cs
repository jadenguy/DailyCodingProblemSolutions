namespace Common.Node
{
    public class ArbitraryTreeBinaryNode : BinaryNode
    {
        private ArbitraryTreeBinaryNode(string value, BinaryNode left = null, BinaryNode right = null, string name = "Root") : base(value, left, right, name)
        {
        }
        public static ArbitraryTreeBinaryNode GenerateArbitaryBinaryTreeNode(ref int count, int seed = 0, string name = "Root")
        {
            count++;
            System.Random rand;
            if (seed == 0) { rand = new System.Random(); }
            else { rand = new System.Random(seed); }
            var ret = new ArbitraryTreeBinaryNode(rand.Next().ToString(), null, null, name);
            if (coinToss(rand)) { ret.Left = GenerateArbitaryBinaryTreeNode(ref count, rand.Next(), ret.Name + ".Left"); }
            if (coinToss(rand)) { ret.Right = GenerateArbitaryBinaryTreeNode(ref count, rand.Next(), ret.Name + ".Right"); }
            return ret;
        }
        private static bool coinToss(System.Random rand)
        {
            return rand.NextDouble() < .5;
        }
    }
}