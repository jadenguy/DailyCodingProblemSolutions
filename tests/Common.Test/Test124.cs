// You have n fair coins and you flip them all at the same time. Any that come up tails you set aside. The ones that come up heads you flip again. How many rounds do you expect to play before only one coin remains?
// Write a function that, given n, returns the number of rounds you'd expect to play until one coin remains.


using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test124
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        [TestCase(1000)]
        public void Problem124(int coins)
        {
            //-- Arrange
            var expected = 2 * (coins - 1);
            var rand = new System.Random(124);
            double delta = Math.Ceiling(Math.Log(coins, 10));
            coins.WriteHost("Coins");
            expected.WriteHost("Expected Flips");
            delta.WriteHost("Delta");

            //-- Act
            var ret = new int[1000];
            Parallel.ForEach(Enumerable.Range(0, 1000), n => ret[n] = Solution124.FlipUntilTails(coins, rand.Next()));
            var actual = ret.Average();
            actual.WriteHost("Actual Flips");

            // //-- Assert
            Assert.AreEqual(expected, actual, delta);
        }
    }
}
