using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node.Graph;

namespace Common
{
    public static class Solution32
    {
        public static bool FindArbitrageBellmanFord(double[,] array, double precision)
        {
            var isThereArbitrage = false;
            var table = array.ToExchangeTable();
            var graphArray = table.ToWeightedGraphArray();
            var BellmanFordChart = graphArray.ToDictionary(k => k, k => double.PositiveInfinity);
            BellmanFordChart[BellmanFordChart.Keys.First()] = 0;
            isThereArbitrage = DetectLoop(BellmanFordChart, precision);
            System.Diagnostics.Debug.WriteLine(BellmanFordChart.Print());
            return isThereArbitrage;
        }

        private static bool DetectLoop(Dictionary<GraphNode, double> BellmanFordChart, double precision)
        {
            BellmanFordChart.BellmanFord(precision);
            var firstRun = BellmanFordChart.ToDictionary(k => k.Key, v => v.Value);
            BellmanFordChart.BellmanFord(precision, true, true);
            var secondRun = BellmanFordChart.ToDictionary(k => k.Key, v => v.Value);
            return secondRun.ContainsValue(double.NegativeInfinity);
        }

        public static Dictionary<GraphNode, double> BellmanFord(this Dictionary<GraphNode, double> BellmanFordChart, double precision = 0, bool onceOver = false, bool detectNegativeCycles = false)
        {
            var connectorList = BellmanFordChart.Keys.SelectMany(g => g.Paths.Select(x => new { Start = g, End = x.Key, Weight = x.Value })).ToList();
            int i = 1;
            System.Diagnostics.Debug.WriteLine(connectorList.Print());
            do
            {
                foreach (var connector in connectorList)
                {
                    var sourceDistance = BellmanFordChart[connector.Start];
                    double currentDistance = BellmanFordChart[connector.End];
                    double pathWeight = connector.Weight;
                    double potentialDistance = sourceDistance + pathWeight;
                    if (potentialDistance + precision < currentDistance)
                    {
                        if (detectNegativeCycles) { BellmanFordChart[connector.End] = double.NegativeInfinity; }
                        else { BellmanFordChart[connector.End] = potentialDistance; }
                    }
                }
                i++;
            } while (!onceOver && i < BellmanFordChart.Count);
            System.Diagnostics.Debug.WriteLine(BellmanFordChart.Print());
            
            return BellmanFordChart;
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