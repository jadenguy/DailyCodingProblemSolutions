using System;

namespace Common.Node
{
    public class LockingBinaryNode : BinaryNode
    {
        private bool locked = false;
        public LockingBinaryNode(string value, BinaryNode left = null, BinaryNode right = null, string name = "Root") : base(value, left, right, name)
        {
        }

        public bool TryLock()
        {
            var ret = false;
            return ret;
        }
    }
}