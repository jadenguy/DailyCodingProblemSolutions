using Common.Node;

namespace Common
{
    public static class Solution24
    {
        public static bool TryLock(this LockingBinaryNode node)
        {
            var ret = false;
            var lockableNode = node as LockingBinaryNode;
            if (lockableNode != null)
            {
                ret = lockableNode.TryLock();
            }
            return ret;
        }
    }
}