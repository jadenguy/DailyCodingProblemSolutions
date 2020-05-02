// The Tower of Hanoi is a puzzle game with three rods and n disks, each a different size.
// All the disks start off on the first rod in a stack. They are ordered by size, with the largest disk on the bottom and the smallest one at the top.
// The goal of this puzzle is to move all the disks from the first rod to the last rod while following these rules:
// •	You can only move one disk at a time.
// •	A move consists of taking the uppermost disk from one of the stacks and placing it on top of another stack.
// •	You cannot place a larger disk on top of a smaller disk.
// Write a function that prints out all the steps necessary to complete the Tower of Hanoi. You should assume that the rods are numbered, with the first rod being 1, the second (auxiliary) rod being 2, and the last (goal) rod being 3.
// For example, with n = 3, we can do this in 7 moves:
// Move 1 to 3
// Move 1 to 2
// Move 3 to 2
// Move 1 to 3
// Move 2 to 1
// Move 2 to 3
// Move 1 to 3


using System.Collections;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test128
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem128(int height, (int from, int to)[] moves)
        {
            //-- Arrange
            var expected = moves;
            height.WriteHost("Height");
            moves.Print("\n", n => "Move " + n.from.ToString() + " to " + n.to.ToString()).WriteHost("Steps");

            //-- Act
            var actual = Solution128.SolveTowerOfHanoi(height);
            actual.Print("\n", n => "Move " + n.from.ToString() + " to " + n.to.ToString()).WriteHost("Actual");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var height = 3;
                var moves = new (int, int)[] { (0, 2), (0, 1), (2, 1), (0, 2), (1, 0), (1, 2), (0, 2) };
                if (Solution128.EnsureSolved(height, moves)) { yield return new object[] { height, moves }; }
                else { WriterExtension.WriteHost("Invalid"); }
                yield break;
            }
        }
    }
}