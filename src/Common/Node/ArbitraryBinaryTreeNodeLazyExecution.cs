using System.Collections.Generic;
using Common.Node;

namespace Common
{
    public class ArbitraryBinaryTreeNodeLazyExecution : BinaryNode<int>
    {
        public bool KnownLeft { get; private set; } = false;
        private readonly System.Random rand;
        public ArbitraryBinaryTreeNodeLazyExecution(int seed = 0)
        {
            if (seed == 0) { rand = new System.Random(); } else { rand = new System.Random(seed); }
        }
        public bool KnownRight { get; private set; } = false;
        public new BinaryNode<int> Left
        {
            get
            {
                if (!KnownLeft)
                {
                    KnownLeft = true;
                    left = coinToss() ? new ArbitraryBinaryTreeNodeLazyExecution(rand.Next()) : null;
                }
                return left;
            }
        }
        public new BinaryNode<int> Right
        {
            get
            {
                if (!KnownRight)
                {
                    KnownRight = true;
                    right = coinToss() ? new ArbitraryBinaryTreeNodeLazyExecution(rand.Next()) : null;
                }
                return right;
            }
        }
        public override IEnumerable<BinaryNode<int>> Children()
        {
            if (Left != null) { yield return Left; }
            if (Right != null) { yield return Right; }
        }
        private bool coinToss() => rand.NextDouble() < .5;
    }
}