// Suppose you are given a table of currency exchange rates, represented as a 2D array. Determine whether there is a possible arbitrage: that is, whether there is some sequence of trades you can make, starting with some amount A of any currency, so that you can end up with some amount greater than A of that currency.
// There are no transaction costs and you can trade fractional quantities.

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test32
    {

        float[,] array;
        [SetUp]
        public void Setup()
        {
            array = new float[2, 3] {
                {1f,1f,2f},
                {1f,1f,1f}
            };
        }
        [Test]
        public void Problem32()
        {
            //-- Arrange
            var expected = false;

            //-- Act
            var actual = (Solution32.Arbitrage(array).FirstOrDefault()).Length;

            //-- Assert        
            Assert.AreEqual(actual, expected);
        }
    }
}