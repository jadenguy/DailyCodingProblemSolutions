// On our special chessboard, two bishops attack each other if they share the same diagonal. This includes bishops that have another bishop located between them, i.e. bishops can attack through pieces.
// You are given N bishops, represented as (row, column) tuples on a M by M chessboard. Write a function to count the number of pairs of bishops that attack each other. The ordering of the pair doesn't matter: (1, 2) is considered the same as (2, 1).
// For example, given M = 5 and the list of bishops:
// •	(0, 0)
// •	(1, 2)
// •	(2, 2)
// •	(4, 0)
// The board would look like this:
// [b 0 0 0 0]
// [0 0 b 0 0]
// [0 0 b 0 0]
// [0 0 0 0 0]
// [b 0 0 0 0]
// You should return 2, since bishops 1 and 3 attack each other, as well as bishops 3 and 4.

using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test068
    {
        (int, int)[][] bishopGroups;
        [SetUp]
        public void Setup()
        {
            var ret = new List<(int, int)[]>();
            ret.Add(new (int, int)[] { (0, 0), (1, 2), (2, 2), (4, 0) });
            ret.Add(new (int, int)[] { (3, 4) });
            bishopGroups = ret.ToArray();
        }
        // [TearDown] public void TearDown(){}
        [Test]
        [TestCase(1, 0)]
        [TestCase(0, 2)]
        public void Problem061(int bishopIndex, int attackPairs)
        {
            //-- Arrange
            var expected = attackPairs;
            (int, int)[] bishops = bishopGroups[bishopIndex];

            //-- Act
            var actual = Solution068.CalculateBishopAttacks(bishops);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}