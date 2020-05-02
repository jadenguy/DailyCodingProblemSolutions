namespace Common.Node
{
    public static class ArbitraryTreeBinaryNode
    {
        public static BinaryNode<int> GenerateArbitaryBinaryTreeNode(int seed = 0, string name = "Root")
        {
            int x = 0;
            return GenerateArbitaryBinaryTreeNode(ref x, seed, name);
        }
        public static BinaryNode<int> GenerateArbitaryBinaryTreeNode(ref int count, int seed = 0, string name = "Root")
        {
            count++;
            var rand = Rand.NewRandom(seed);
            var coin = new Coin(rand.Next(1, int.MaxValue));
            var ret = new BinaryNode<int>(rand.Next(), null, null, name);
            if (coin.Flip()) { ret.Left = GenerateArbitaryBinaryTreeNode(ref count, rand.Next(), ret.Name + ".Left"); }
            if (coin.Flip()) { ret.Right = GenerateArbitaryBinaryTreeNode(ref count, rand.Next(), ret.Name + ".Right"); }
            return ret;
        }
    }
}