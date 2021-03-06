// On our special chessboard, two bishops attack each other if they share the same diagonal. This includes bishops that have another bishop located between them, i.e. bishops can attack through pieces.
// You are given N bishops, represented as (row, column) tuples on a M by M chessboard. Write a function to count the number of pairs of bishops that attack each other. The ordering of the pair doesn't matter: (1, 2) is considered the same as (2, 1).
// For example, given M = 5 and the list of bishops:
// *	(0, 0)
// *	(1, 2)
// *	(2, 2)
// *	(4, 0)
// The board would look like this:
// [b 0 0 0 0]
// [0 0 b 0 0]
// [0 0 b 0 0]
// [0 0 0 0 0]
// [b 0 0 0 0]
using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test532
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        //[Test]
        public void Problem532()
        {
            //-- Assert

            //-- Arrange

            //-- Act
            Assert.Pass();
        }
    }
}
