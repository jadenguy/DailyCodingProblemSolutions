using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Forex;

namespace Common
{
    public static class Solution32
    {
        public static IEnumerable<(int, int)[]> FindArbitrage(decimal[,] array, decimal precision = 0)
        {
            CurrencyExchangeTable dict = TurnArrayToDictionaryOfExchangeValues(array);
            return Arbitrate(dict, precision);
        }
        private static IEnumerable<(int, int)[]> Arbitrate(CurrencyExchangeTable dict, decimal precision)
        {
            foreach (var item in GenerateLoops(dict))
            {
                var loop = item.ToArray();
                if (IsArbitrage(dict, loop, precision, out var log))
                {
                    System.Diagnostics.Debug.WriteLine(log);
                    yield return loop.Select(l => (l.OldCurrency.Id, l.NewCurrency.Id)).ToArray();
                    System.Diagnostics.Debug.WriteLine("");
                }
            };
        }
        private static bool IsArbitrage(CurrencyExchangeTable dict, Exchange[] loop, decimal precision, out string log)
        {
            const decimal startingMoney = 1;
            var v = startingMoney + precision;
            var money = startingMoney;
            var outString = new StringBuilder();
            Currency startingCurrency = loop[0].OldCurrency;
            outString.AppendLine($"Starting with {money.ToString("0.00")} in {startingCurrency}");
            var isArbitrage = false;
            var yahtzee = false;
            foreach (Exchange exchange in loop)
            {
                money *= dict[exchange];
                var newCurrency = exchange.NewCurrency;
                if (newCurrency != startingCurrency && dict.Keys.Contains(new Exchange(newCurrency, startingCurrency)))
                {
                    decimal exchangeRate = dict[new Exchange(newCurrency, startingCurrency)];
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
            return isArbitrage;
        }

        private static CurrencyExchangeTable TurnArrayToDictionaryOfExchangeValues(decimal[,] array)
        {
            var dict = new CurrencyExchangeTable();
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
                    var exchange = new Exchange(xCurrency, yCurrency);
                    dict[exchange] = array[x, y];
                    var reverseExchange = new Exchange(yCurrency, xCurrency);
                    
                    System.Diagnostics.Debug.Write($"{exchange} for ");
                    System.Diagnostics.Debug.WriteLine(array[x, y]);
                    if (array[x, y] == 0) { dict[reverseExchange] = 0; }
                    else { dict[reverseExchange] = 1 / array[x, y]; }
                }
            }
            return dict;
        }
        private static IEnumerable<ExchangeChain> GenerateLoops(CurrencyExchangeTable dict)
        {
            foreach (var startingLink in dict.Keys)
            {
                var newChain = new ExchangeChain() { startingLink };
                foreach (var loopChain in newChain.AddLink(dict))
                {
                    yield return loopChain;
                }
            }
        }
        private static IEnumerable<ExchangeChain> AddLink(this ExchangeChain chain, CurrencyExchangeTable dict)
        {
            var last = chain.Last();
            var all = dict.Keys;
            var matchingLinks = all.Where(x => chain.Contains(x) == false).Where(x => x.OldCurrency == last.NewCurrency).ToArray();
            if (chain.IsLoop())
            {
                yield return chain;
            }
            else if (matchingLinks.Length == 0) { }
            else
            {
                foreach (var nextLink in matchingLinks)
                {
                    if (nextLink.NewCurrency != last.OldCurrency || nextLink.OldCurrency != last.NewCurrency || dict[last] * dict[nextLink] != 1)
                    {
                        var newChain = new ExchangeChain(chain) { nextLink };
                        foreach (var nextChain in newChain.AddLink(dict))
                        {
                            yield return nextChain;
                        }
                    }
                }
            }
        }
        private static bool IsLoop(this ExchangeChain list)
        {
            Exchange current;
            var previous = list.Last();
            var ret = true;
            for (int i = 0; ret && i < list.Count; i++)
            {
                current = list[i];
                ret = current.OldCurrency == previous.NewCurrency;
                previous = current;
            }
            return ret;
        }
    }
}