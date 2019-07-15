namespace Common.Node
{
    public static class ArbitraryTreeBinaryNode
    {
        public static BinaryNode<int> GenerateArbitaryBinaryTreeNode(ref int count, int seed = 0, string name = "Root")
        {
            count++;
            System.Random rand;
            if (seed == 0) { rand = new System.Random(); }
            else { rand = new System.Random(seed); }
            var ret = new BinaryNode<int>(rand.Next(), null, null, name);
            if (coinToss(rand)) { ret.Left = GenerateArbitaryBinaryTreeNode(ref count, rand.Next(), ret.Name + ".Left"); }
            if (coinToss(rand)) { ret.Right = GenerateArbitaryBinaryTreeNode(ref count, rand.Next(), ret.Name + ".Right"); }
            return ret;
        }
        private static bool coinToss(System.Random rand) => rand.NextDouble() < .5;
    }
}