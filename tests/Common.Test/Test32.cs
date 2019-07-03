// Suppose you are given a table of currency exchange rates, represented as a 2D array. Determine whether there is a possible arbitrage: that is, whether there is some sequence of trades you can make, starting with some amount A of any currency, so that you can end up with some amount greater than A of that currency.
// There are no transaction costs and you can trade fractional quantities.

using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test32
    {

        decimal[,] array;
        [SetUp]
        public void Setup()
        {
            array = new decimal[,] {
                {3,3},
                {2,2},
                {1,1}
            };
        }
        [Test]        
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(true)]
        [TestCase(false)]
        public void Problem32(bool arbitrage)
        {
            //-- Arrange
            var expected = arbitrage;
            if (arbitrage)
            {
                var rand = new System.Random();
                array[rand.Next(array.GetLowerBound(0)), rand.Next(array.GetLowerBound(1))] *= 1.01m;
            }

            //-- Act
            // var stopWatch = new Stopwatch();
            // stopWatch.Start();
            var arbitrageSolution = Solution32.FindArbitrage(array).FirstOrDefault();
            var actual = arbitrageSolution != null;
            // System.Diagnostics.Debug.WriteLine(stopWatch.ElapsedMilliseconds);
            // System.Console.WriteLine(stopWatch.ElapsedMilliseconds);
            // System.Diagnostics.Debug.WriteLine("");
            // System.Console.WriteLine("");

            //-- Assert        
            Assert.AreEqual(expected, actual);
        }
    }
}