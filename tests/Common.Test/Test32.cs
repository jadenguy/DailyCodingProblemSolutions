// Suppose you are given a table of currency exchange rates, represented as a 2D array. Determine whether there is a possible arbitrage: that is, whether there is some sequence of trades you can make, starting with some amount A of any currency, so that you can end up with some amount greater than A of that currency.
// There are no transaction costs and you can trade fractional quantities.

using System.Diagnostics;
using System.Linq;
using Common.Extensions;
using Common.Forex;
using NUnit.Framework;

namespace Common.Test
{
    public class Test32
    {

        decimal[,] array;
        string[] currencyNames;
        CurrencyExchangeTable table;
        [SetUp]
        public void Setup()
        {
            array = new decimal[,] {
                {5,5},
                {3,3},
                {2,2},
                {1,1}
            };
            currencyNames = new string[] { "USD", "JPY", "EUR", "BTC" };
            var USD = new Currency(0, currencyNames[0]);
            var JPY = new Currency(1, currencyNames[1]);
            var EUR = new Currency(2, currencyNames[2]);
            var BTC = new Currency(3, currencyNames[3]);
            table = new CurrencyExchangeTable();
            table.Add(new Exchange(USD, JPY, 95.0122490M));
            table.Add(new Exchange(JPY, EUR, 0.0081386M));
            table.Add(new Exchange(BTC, USD, 134.8500652M));
            table.Add(new Exchange(JPY, BTC, 0.0000869M));
            table.Add(new Exchange(USD, EUR, 0.7213620M));
            table.Add(new Exchange(EUR, USD, 1.1309384M));
            table.Add(new Exchange(EUR, JPY, 115.8737287M));
            table.Add(new Exchange(JPY, USD, 0.0104622M));
            table.Add(new Exchange(EUR, BTC, 0.0099016M));
            table.Add(new Exchange(BTC, JPY, 13804.0907039M));
            table.Add(new Exchange(BTC, EUR, 99.4688319M));
            table.Add(new Exchange(USD, BTC, 0.0076985M));
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(true)]
        [TestCase(false)]
        public void Problem32Naive(bool arbitrage)
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
            var actual = arbitrageSolution.Ratio != 0;
            // System.Diagnostics.Debug.WriteLine(stopWatch.ElapsedMilliseconds);
            // System.Console.WriteLine(stopWatch.ElapsedMilliseconds);
            // System.Diagnostics.Debug.WriteLine("");
            // System.Console.WriteLine("");
            // System.Console.WriteLine(arbitrageSolution.Item1.Print());
            // System.Diagnostics.Debug.WriteLine(arbitrageSolution.Item1.Print());

            //-- Assert        
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem32FullCrossNaive()
        {
            //-- Arrange
            // var expected = arbitrage;
            // if (arbitrage)
            // {
            // var rand = new System.Random();
            // array[rand.Next(array.GetLowerBound(0)), rand.Next(array.GetLowerBound(1))] *= 1.01m;
            // }

            //-- Act
            // var stopWatch = new Stopwatch();
            // stopWatch.Start();
            var arbitrageSolution = Solution32.Arbitrate(table).ToArray();
            // System.Diagnostics.Debug.WriteLine(stopWatch.ElapsedMilliseconds);
            // System.Console.WriteLine(stopWatch.ElapsedMilliseconds);
            // System.Diagnostics.Debug.WriteLine("");
            // System.Console.WriteLine("");

            //-- Assert        
            // Assert.AreEqual(expected, actual);
            var bestArbitrage = arbitrageSolution.OrderByDescending(x => x.Ratio).FirstOrDefault();
            var shortestBest = arbitrageSolution.Where(s => s.Ratio == bestArbitrage.Ratio).ToArray().OrderBy(o => o.Chain.ToArray().Length).FirstOrDefault();
            
            
            System.Diagnostics.Debug.WriteLine(shortestBest.Ratio);
            System.Diagnostics.Debug.WriteLine(shortestBest.Chain.Print());
            var money = 1000000M;
            System.Diagnostics.Debug.Write(money + " ");
            System.Diagnostics.Debug.WriteLine(shortestBest.Chain[0].OldCurrency);
            foreach (var item in shortestBest.Chain)
            {
                money *= item.ExchangeRate;
                string value = $"{money} in {item.NewCurrency}";
                System.Diagnostics.Debug.WriteLine(value);
            }
        }
    }
}