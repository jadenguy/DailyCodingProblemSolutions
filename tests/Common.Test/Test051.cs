// Given a function that generates perfectly random numbers between 1 and k (inclusive), where k is an input, write a function that shuffles a deck of cards represented as an array using only swaps.
// It should run in O(N) time.
// Hint: Make sure each one of the 52! permutations of the deck is equally likely.

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test051
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem051()
        {
            //-- Arrange
            int cards = 3;
            double expected = ((double)cards) / 2 + .5;

            //-- Act
            var actual = Solution051.SwapShuffleDeck(cards: cards).Average();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}