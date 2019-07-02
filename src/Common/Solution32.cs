using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution32
    {
        public enum Currency
        {
            invalid = -1,
            A, B, C, D, E, F, G, H, I, J, K, L, M,
            N, O, P, Q, R, S, T, U, V, W, X, Y, Z
        }
        public static IEnumerable<(int, int)[]> Arbitrage(float[,] array)
        {
            Dictionary<(Currency, Currency), float> dict = TurnArrayToDictionaryOfExchangeValues(array);
            return Arbitrate(dict);
        }
        private static IEnumerable<(int, int)[]> Arbitrate(Dictionary<(Currency, Currency), float> dict)
        {
            foreach (var item in GenerateLoops(dict))
            {
                var loop = item.ToArray();
                var money = 100f;
                foreach (var exchange in loop) { money *= dict[exchange]; }
                if (money > 100f)
                {
                    var money2 = 100f;
                    Currency startingCurrency = loop[0].Item1;
                    System.Diagnostics.Debug.WriteLine($"{money2} of {startingCurrency}");
                    foreach (var exchange in loop)
                    {
                        money2 *= dict[exchange];
                        var newCurrency = exchange.Item2;
                        try
                        {
                            var money3 = money2 * dict[(newCurrency, startingCurrency)];
                            System.Diagnostics.Debug.WriteLine($"{money3} in {newCurrency}");
                        }
                        catch
                        {
                            System.Diagnostics.Debug.WriteLine($"{money2} in {newCurrency}, no direct exchange to {startingCurrency}");
                        }
                    }
                    yield return loop.Select(l => ((int)l.Item1, (int)l.Item2)).ToArray();
                }
            };
        }

        private static Dictionary<(Currency, Currency), float> TurnArrayToDictionaryOfExchangeValues(float[,] array)
        {
            var dict = new Dictionary<(Currency, Currency), float>();
            for (int x = 0; x <= array.GetUpperBound(0); x++)
            {
                var xCurrency = (Currency)x;
                for (int y = 0; y <= array.GetUpperBound(1); y++)
                {
                    var yCurrency = (Currency)(1 + array.GetUpperBound(0) + y);
                    dict[(xCurrency, yCurrency)] = array[x, y];
                    System.Diagnostics.Debug.Write(xCurrency);
                    System.Diagnostics.Debug.Write(yCurrency);
                    System.Diagnostics.Debug.WriteLine(array[x, y]);
                    if (array[x, y] == 0) { dict[(yCurrency, xCurrency)] = 0; }
                    else { dict[(yCurrency, xCurrency)] = 1f / array[x, y]; }
                }
            }
            return dict;
        }
        private static IEnumerable<List<(Currency, Currency)>> GenerateLoops(Dictionary<(Currency, Currency), float> dict)
        {
            foreach (var startingLink in dict.Keys)
            {
                var newChain = new List<(Currency, Currency)>() { startingLink };
                foreach (var loopChain in newChain.AddLink(dict))
                {
                    yield return loopChain;
                }
            }
        }
        private static IEnumerable<List<(Currency, Currency)>> AddLink(this List<(Currency, Currency)> chain, Dictionary<(Currency, Currency), float> dict)
        {
            var last = chain.Last();
            var all = dict.Keys;
            var matchingLinks = all.Where(x => chain.Contains(x) == false).Where(x => x.Item1 == last.Item2).ToArray();
            if (chain.IsLoop())
            {
                yield return chain;
            }
            else if (matchingLinks.Length == 0) { }
            else
            {
                foreach (var nextLink in matchingLinks)
                {
                    var newChain = new List<(Currency, Currency)>(chain) { nextLink };
                    foreach (var nextChain in newChain.AddLink(dict))
                    {
                        yield return nextChain;
                    }
                }
            }
        }
        private static bool IsLoop(this List<(Currency, Currency)> list)
        {
            (Currency, Currency) current = (Currency.invalid, Currency.invalid);
            (Currency, Currency) previous = list.Last();
            var ret = true;
            for (int i = 0; ret && i < list.Count; i++)
            {
                current = list[i];
                ret = current.Item1 == previous.Item2;
                previous = current;
            }
            return ret;
        }
    }
}