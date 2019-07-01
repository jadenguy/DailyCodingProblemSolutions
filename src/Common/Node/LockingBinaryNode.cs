using System;

namespace Common.Node
{
    public class LockingBinaryNode : BinaryNode
    {
        private bool unlocked = true;
        public LockingBinaryNode(string value, BinaryNode left = null, BinaryNode right = null, string name = "Root") : base(value, left, right, name)
        {
        }
        public bool IsLockeable { get => this.TryLock(false); }
        public bool TryLock(bool actuallyLock = true)
        {
            var ret = true;
            if (unlocked)
            {
                var childEnumerator = this.Children().GetEnumerator();
                while (ret && childEnumerator.MoveNext())
                {
                    var child = childEnumerator.Current as LockingBinaryNode;
                    if (child != null) { ret &= child.TryLock(false); }
                }
            }
            else { ret = false; }
            if (ret && actuallyLock) { unlocked = false; }
            return ret;
        }
    }
}