// Suppose you are given a table of currency exchange rates, represented as a 2D array. Determine whether there is a possible arbitrage: that is, whether there is some sequence of trades you can make, starting with some amount A of any currency, so that you can end up with some amount greater than A of that currency.
// There are no transaction costs and you can trade fractional quantities.

using System;
using System.Diagnostics;
using System.Linq;
using Common.Extensions;
using Common.Forex;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test032
    {
        private const double percentageMarketIsOff = 1.1;
        double[][,] arraysArray;
        string[] currencyNames;
        CurrencyExchangeTable table;
        [SetUp]
        public void Setup()
        {
            arraysArray = new double[][,]{
                    new double[,] {
                        {2,6},
                        {1,3}
                    },
                    new double[,] {
                        {3,9,15},
                        {2,6,10},
                        {1,3,5}
                    },
                    new double[,] {
                        {5,5,5,5},
                        {3,3,3,3},
                        {2,2,2,2},
                        {1,1,1,1}
                    },
                    new double[,] {
                        {1,2,3,5,7,11,13,17,19},
                        {2,4,6,10,14,22,26,34,38},
                        {3,6,9,15,21,33,39,51,57},
                        {4,8,12,20,28,44,52,68,76},
                        {5,10,15,25,35,55,65,85,95},
                        {6,12,18,30,42,66,78,102,114},
                        {7,14,21,35,49,77,91,119,133},
                        {8,16,24,40,56,88,104,136,152},
                        {9,18,27,45,63,99,117,153,171}
                    }
                };
            currencyNames = new string[] { "USD", "JPY", "EUR", "BTC" };
            var USD = new Currency(0, currencyNames[0]);
            var JPY = new Currency(1, currencyNames[1]);
            var EUR = new Currency(2, currencyNames[2]);
            var BTC = new Currency(3, currencyNames[3]);
            table = new CurrencyExchangeTable() {
                new Exchange(USD, JPY, 95.0122490),
                new Exchange(JPY, EUR, 0.0081386),
                new Exchange(BTC, USD, 134.8500652),
                new Exchange(JPY, BTC, 0.0000869),
                new Exchange(USD, EUR, 0.7213620),
                new Exchange(EUR, USD, 1.1309384),
                new Exchange(EUR, JPY, 115.8737287),
                new Exchange(JPY, USD, 0.0104622),
                new Exchange(EUR, BTC, 0.0099016),
                new Exchange(BTC, JPY, 13804.0907039),
                new Exchange(BTC, EUR, 99.4688319),
                new Exchange(USD, BTC, 0.0076985)
            };
        }
        [Test]
        [TestCase(true, 0)]
        [TestCase(false, 0)]
        [TestCase(true, 1)]
        [TestCase(false, 1)]
        [TestCase(true, 2)]
        // [TestCase(false, 2)]//bogs down for 16 symmetrical exchanges
        [TestCase(true, 3)] // If there's arbitrage and you run chain together all the exchanges, guaranteed result fairly quickly
        // [TestCase(false, 1)] //Too slow
        public void Problem32Naive(bool arbitrage, int arrayIndex)
        {
            //-- Arrange
            var expected = arbitrage;
            var array = arraysArray[arrayIndex];
            if (arbitrage)
            {
                var rand = new System.Random();
                array[rand.Next(array.GetLowerBound(0)), rand.Next(array.GetLowerBound(1))] *= percentageMarketIsOff;
            }

            //-- Act
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var arbitrageSolution = Solution032.ArbitrateNaive(array, .0000000001).FirstOrDefault();
            var actual = (arbitrageSolution?.Ratio ?? 0) != 0;
            System.Diagnostics.Debug.WriteLine(stopWatch.ElapsedMilliseconds);
            System.Console.WriteLine(stopWatch.ElapsedMilliseconds);
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine("");
            System.Console.WriteLine(arbitrageSolution?.Chain.Print());
            System.Diagnostics.Debug.WriteLine(arbitrageSolution?.Chain.Print());

            //-- Assert        
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase(true, 0)]
        [TestCase(false, 0)]
        [TestCase(true, 1)]
        [TestCase(false, 1)]
        [TestCase(true, 2)]
        [TestCase(false, 2)]
        [TestCase(true, 3)]
        [TestCase(false, 3)]
        public void Problem32BellmanFord(bool arbitrage, int arrayIndex)
        {
            //-- Arrange
            var expected = arbitrage;
            var array = arraysArray[arrayIndex];
            if (arbitrage)
            {
                var rand = new System.Random();
                array[rand.Next(array.GetLowerBound(0)), rand.Next(array.GetLowerBound(1))] *= percentageMarketIsOff;
            }

            //-- Act
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var actual = Solution032.FindArbitrageBellmanFord(array, .0000000001);
            System.Diagnostics.Debug.WriteLine(stopWatch.ElapsedMilliseconds);
            System.Console.WriteLine(stopWatch.ElapsedMilliseconds);
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine("");

            //-- Assert        
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem32TableNaive()
        {
            //-- Arrange
            // var expected = true;

            //-- Act
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var arbitrageSolution = Solution032.ArbitrateNaive(table).ToArray();
            // var actual = true;
            System.Diagnostics.Debug.WriteLine(stopWatch.ElapsedMilliseconds);
            System.Console.WriteLine(stopWatch.ElapsedMilliseconds);
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine("");
            var bestArbitrage = arbitrageSolution.OrderByDescending(x => x.Ratio).FirstOrDefault();
            var shortestBest = arbitrageSolution.Where(s => s.Ratio == bestArbitrage.Ratio).ToArray().OrderBy(o => o.Chain.ToArray().Length).FirstOrDefault();

            // System.Diagnostics.Debug.WriteLine(shortestBest.Ratio);
            // System.Diagnostics.Debug.WriteLine(shortestBest.Chain.Print());
            var money = 1000000.0;
            System.Diagnostics.Debug.Write(money + " ");
            System.Diagnostics.Debug.WriteLine(shortestBest.Chain[0].OldCurrency);
            foreach (var item in shortestBest.Chain)
            {
                money *= item.ExchangeRate;
                string value = $"{money} in {item.NewCurrency}";
                System.Diagnostics.Debug.WriteLine(value);
            }

            //-- Assert        
            Assert.Pass(); //I wonder what the best arbitrage would be
        }
        [Test]
        public void BellmanFordGraphNoArbitrage()
        {
            //-- Arrange
            var graphArray = new GraphNode[] {
                new GraphNode("GOLD"),
                new GraphNode("NZD"),
                new GraphNode("SEK"),
                new GraphNode("CNY"),
                new GraphNode("CHF"),
                new GraphNode("CAD"),
                new GraphNode("AUD"),
                new GraphNode("GBP"),
                new GraphNode("JPY"),
                new GraphNode("EUR"),
                new GraphNode("USD"),
            };
            var bellmanFordChart = graphArray.ToDictionary(k => k, v => double.PositiveInfinity);
            bellmanFordChart[graphArray[0]] = 0;
            // var expected = true;
            var rand = new System.Random();
            var rootNode = graphArray[0]; //create a gold currency
            foreach (var otherNode in graphArray.Where(o => o != rootNode).Where(o => !o.Paths.ContainsKey(rootNode))) //create creates an exchange rate for each currency against gold
            {
                double weight = rand.NextDouble();
                negLog(rootNode, otherNode, weight);
            }
            foreach (var node in graphArray) //create a fair market against gold currency
            {
                foreach (var otherNode in graphArray.Where(o => o != node).Where(o => !o.Paths.ContainsKey(node)))
                {
                    double weight = otherNode.Paths[rootNode] * rootNode.Paths[node];
                    negLog(node, otherNode, weight);
                }
            }

            //-- Act
            var isConnected = bellmanFordChart.BellmanFord(0.000000001).All(v => !double.IsPositiveInfinity(v.Value)); //really small numbers require really small precision checks
            var noLoop = bellmanFordChart.BellmanFord(0.000000001, true, true).All(v => !double.IsNegativeInfinity(v.Value)); //really small numbers require really small precision checks

            //-- Assert
            Assert.IsTrue(isConnected, "Some node is not connected");
            Assert.IsTrue(noLoop, "A negative loop was detected");
        }

        private static void negLog(GraphNode node, GraphNode otherNode, double weight)
        {
            node.ConnectTo(otherNode, -Math.Log(weight));
            if (weight == 0) { otherNode.ConnectTo(node, 0); }
            else { otherNode.ConnectTo(node, -Math.Log(1 / weight)); }
        }


    }
}