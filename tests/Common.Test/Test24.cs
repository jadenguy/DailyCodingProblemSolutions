// Implement locking in a binary tree. A binary tree node can be locked or unlocked only if all of its descendants or ancestors are not locked.
// Design a binary tree node class with the following methods:
// •	is_locked, which returns whether the node is locked
// •	lock, which attempts to lock the node. If it cannot be locked, then it should return false. Otherwise, it should lock it and return true.
// •	unlock, which unlocks the node. If it cannot be unlocked, then it should return false. Otherwise, it should unlock it and return true.
// You may augment the node to add parent pointers or any other property you would like. You may assume the class is used in a single-threaded program, so there is no need for actual locks or mutexes. Each method should run in O(h), where h is the height of the tree.


using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test24
    {
        [SetUp]
        public void Setup() { }
        [Test]
        public void Problem24TryLock()
        {
            //-- Arrange
            var root = new LockingBinaryNode("0");
            root.Left = new LockingBinaryNode("1");
            root.Right = new LockingBinaryNode("0");
            root.Right.Right = new LockingBinaryNode("0");
            root.Right.Left = new LockingBinaryNode("1");
            root.Right.Left.Left = new LockingBinaryNode("1");
            root.Right.Left.Right = new LockingBinaryNode("1");
            var expectedRoot = false;
            var expectedRR = true;

            //-- Act
            root.Right.Left.TryLock();
            var actualRoot = root.TryLock();
            var actualRR = root.Right.Right.TryLock();

            //-- Assert
            Assert.AreEqual(expectedRoot, actualRoot);
            Assert.AreEqual(expectedRR, actualRR);
        }
    }
}