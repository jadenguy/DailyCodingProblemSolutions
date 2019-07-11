using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node;

namespace Common
{
    public static class Solution32
    {
        public static bool FindArbitrageBellmanFord(double[,] array, double precision = 0)
        {
            var isThereArbitrage = false;
            var table = array.ToExchangeTable();
            var graphArray = table.ToWeightedGraphArray();
            var bellmanFordChart = graphArray.ToDictionary(k => k, k => double.PositiveInfinity);
            bellmanFordChart[bellmanFordChart.Keys.First()] = 0;
            isThereArbitrage = DetectLoop(bellmanFordChart, precision);
            System.Diagnostics.Debug.WriteLine(bellmanFordChart.Print());
            return isThereArbitrage;
        }

        private static bool DetectLoop(Dictionary<GraphNode, double> bellmanFordChart, double precision)
        {
            bellmanFordChart.BellmanFord(precision);
            return bellmanFordChart.BellmanFord(precision, true, true).ContainsValue(double.NegativeInfinity);
        }
        public static Dictionary<GraphNode, double> BellmanFord(this Dictionary<GraphNode, double> bellmanFordChart, double precision = 0, bool detectNegativeCycles = false,bool onceOver = false)
        {
            var connectorList = bellmanFordChart.Keys.SelectMany(g => g.Paths.Select(x => new { Start = g, End = x.Key, Weight = x.Value })).Random().ToArray();
            int i = 1;
            var same = true;
            System.Diagnostics.Debug.WriteLine(connectorList.Print());
            do
            {
                var old = bellmanFordChart.ToDictionary(k => k.Key, v => v.Value);
                foreach (var connector in connectorList)
                {
                    var sourceDistance = bellmanFordChart[connector.Start];
                    double currentDistance = bellmanFordChart[connector.End];
                    double pathWeight = connector.Weight;
                    double potentialDistance = sourceDistance + pathWeight;
                    if (potentialDistance + precision < currentDistance)
                    {
                        if (detectNegativeCycles) { bellmanFordChart[connector.End] = double.NegativeInfinity; }
                        else { bellmanFordChart[connector.End] = potentialDistance; }
                    }
                }
                i++;
                System.Diagnostics.Debug.WriteLine(bellmanFordChart.Print());
                same = bellmanFordChart.Keys.All(item => old[item] == bellmanFordChart[item]);
            } while (!onceOver && !same && i < bellmanFordChart.Count);
            return bellmanFordChart;
        }
        public static GraphNode[] ToWeightedGraphArray(this Forex.CurrencyExchangeTable table)
        {
            var fullList = table.Select(x => x.OldCurrency).Distinct().Select(c => new GraphNode(c.Name)).ToArray();
            foreach (var exchange in table)
            {
                var oldCurrency = fullList.Where(n => n.Id == exchange.OldCurrency.Name).First();
                var newCurrency = fullList.Where(n => n.Id == exchange.NewCurrency.Name).First();
                oldCurrency.ConnectTo(newCurrency, -Math.Log((double)(exchange.ExchangeRate)));
            }
            return fullList;
        }
    }
}