﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Forex;

namespace Common
{
    public static class Solution32Naive
    {
        public static IEnumerable<Arbitrage> FindArbitrage(double[,] array, double precision = 0) => Arbitrate(array.ToExchangeTable(), precision);
        public static IEnumerable<Arbitrage> Arbitrate(CurrencyExchangeTable list, double precision = 0)
        {
            foreach (var item in GenerateLoops(list))
            {
                var loop = item;
                if (IsLoopArbitrage(list, loop, out var log, out var ratio, precision))
                {
                    // System.Diagnostics.Debug.WriteLine(log);
                    yield return new Arbitrage(loop, ratio);
                    // System.Diagnostics.Debug.WriteLine("");
                }
            };
        }
        public static bool IsLoopArbitrage(CurrencyExchangeTable list, ExchangeChain loop, out string log, out double ratio, double precision = 0)
        {
            const double startingMoney = 1;
            var v = startingMoney + precision;
            var money = startingMoney;
            var outString = new StringBuilder();
            Currency startingCurrency = loop[0].OldCurrency;
            outString.AppendLine($"{money.ToString("0.00")} in {startingCurrency} to start with");
            var isArbitrage = false;
            var yahtzee = false;
            foreach (Exchange exchange in loop)
            {
                money *= exchange.ExchangeRate;
                var newCurrency = exchange.NewCurrency;
                var enumerable = list.Where(x => x.OldCurrency == newCurrency && x.NewCurrency == startingCurrency);
                if (newCurrency != startingCurrency && enumerable.Any())
                {
                    double exchangeRate = enumerable.First().ExchangeRate;
                    var oldMoney = money * exchangeRate;
                    outString.AppendLine($"{oldMoney.ToString("0.00")} in {newCurrency}");
                    if (!yahtzee && oldMoney > v)
                    {
                        outString.AppendLine("Yahtzee!");
                        yahtzee = true;
                    }
                }
                else { outString.AppendLine($"{money.ToString("0.00")} in {newCurrency}, no direct exchange to {startingCurrency}"); }
            }
            isArbitrage = money > v;
            outString.AppendLine($"ending with {money.ToString("0.00")} in {startingCurrency}");
            log = outString.ToString();
            ratio = money;
            return isArbitrage;
        }
        public static CurrencyExchangeTable ToExchangeTable(this double[,] array)
        {
            var list = new CurrencyExchangeTable();
            var yList = new Dictionary<int, Currency>();
            var rand = new Random();
            for (int y = 0; y <= array.GetUpperBound(1); y++)
            {
                yList.Add(y, new Currency(y, rand.Next().GetHashCode().ToString("X")));
            }
            for (int x = 0; x <= array.GetUpperBound(0); x++)
            {
                var xCurrency = new Currency(x, rand.Next().GetHashCode().ToString("X"));
                for (int y = 0; y <= array.GetUpperBound(1); y++)
                {
                    var yCurrency = yList[y];
                    var exchange = new Exchange(xCurrency, yCurrency, array[x, y]);
                    list.Add(exchange);
                    var reverseExchange = new Exchange(yCurrency, xCurrency);
                    if (array[x, y] == 0) { reverseExchange.ExchangeRate = 0; }
                    else { reverseExchange.ExchangeRate = 1 / array[x, y]; }
                    list.Add(reverseExchange);
                }
            }
            return list;
        }
        private static IEnumerable<ExchangeChain> GenerateLoops(CurrencyExchangeTable list)
        {
            foreach (var startingLink in list)
            {
                var newChain = new ExchangeChain() { startingLink };
                foreach (var loopChain in newChain.AddLink(list))
                {
                    yield return loopChain;
                }
            }
        }
        private static IEnumerable<ExchangeChain> AddLink(this ExchangeChain chain, CurrencyExchangeTable list)
        {
            var last = chain.Last();
            var matchingLinks = list.Where(x => chain.Contains(x) == false).Where(x => x.OldCurrency == last.NewCurrency).ToArray();
            if (chain.IsLoop())
            {
                yield return chain;
            }
            else if (matchingLinks.Length == 0) { }
            else
            {
                foreach (var nextLink in matchingLinks)
                {
                    if (nextLink.NewCurrency != last.OldCurrency || nextLink.OldCurrency != last.NewCurrency || last.ExchangeRate * nextLink.ExchangeRate != 1)
                    {
                        var newChain = new ExchangeChain(chain) { nextLink };
                        foreach (var nextChain in newChain.AddLink(list))
                        {
                            yield return nextChain;
                        }
                    }
                }
            }
        }
        private static bool IsLoop(this ExchangeChain chain)
        {
            Exchange current;
            var previous = chain.Last();
            var ret = true;
            for (int i = 0; ret && i < chain.Count; i++)
            {
                current = chain[i];
                ret = current.OldCurrency == previous.NewCurrency;
                previous = current;
            }
            return ret;
        }
        // public static IEnumerable<Arbitrage> FindArbitrageBellmanFord(double[,] array, double precision = 0)
        // {
        //     CurrencyExchangeTable list = TurnArrayToDictionaryOfExchangeValues(array);
        //     return ArbitrateBellmanFord(list, precision);
        // }
        // private static IEnumerable<Arbitrage> ArbitrateBellmanFord(CurrencyExchangeTable list, double precision)
        // {
        //     throw new NotImplementedException();
        // }
    }
}