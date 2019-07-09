using System;
using System.Linq;
using Common.Extensions;
using Common.Node.Graph;

namespace Common
{
    public static class Solution32
    {
        public static bool FindArbitrageBellmanFord(decimal[,] array)
        {
            var isThereArbitrage = true;
            var table = array.ToExchangeTable();
            var graphArray = table.ToWeightedGraphArray();
            var list = graphArray.First().BreadthFirstSearch().SelectMany(g => g.Paths).Select(p => (WeightedGraphPath)p).Select(w => new {Next = w.Next,Weight = -Math.Log((double)w.Weight)}).ToArray();



            return isThereArbitrage;
        }
        public static WeightedGraphNode[] ToWeightedGraphArray(this Forex.CurrencyExchangeTable table)
        {
            var fullList = table.Select(x => x.OldCurrency).Distinct().Select(c => new WeightedGraphNode(c.Name)).ToArray();
            foreach (var exchange in table)
            {
                var oldCurrency = fullList.Where(n => n.Name == exchange.OldCurrency.Name).First();
                var newCurrency = fullList.Where(n => n.Name == exchange.NewCurrency.Name).First();
                oldCurrency.ConnectTo(newCurrency, exchange.ExchangeRate);
            }
            return fullList;
        }
    }
}