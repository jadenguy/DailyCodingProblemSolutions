using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution32
    {
        public enum Currency
        {
            A, B, C, D, E, F, G, H, I, J, K, L, M,
            N, O, P, Q, R, S, T, U, V, W, X, Y, Z
        }
        public class Money
        {
            public Money(Currency currency, float amount)
            {
                this.Currency = currency;
                this.Amount = amount;

            }
            public Currency Currency { get; set; }
            public float Amount { get; set; }
        }
        public static IEnumerable<(int, int)[]> Arbitrage(float[,] array, int fee = 1)
        {
            Dictionary<(Currency, Currency), float> dict = TurnArrayToDictionaryOfExchangeValues(array);
            var x = new List<(Currency, Currency)>(dict.Keys);
            System.Diagnostics.Debug.WriteLine(IsLoop(x));
            yield return new (int, int)[] { };
        }
        private static Dictionary<(Currency, Currency), float> TurnArrayToDictionaryOfExchangeValues(float[,] array)
        {
            var dict = new Dictionary<(Currency, Currency), float>();
            for (int x = 1; x <= array.GetUpperBound(0); x++)
            {
                var xCurrency = (Currency)x+1;
                for (int y = 0; y <= array.GetUpperBound(1); y++)
                {
                    var yCurrency = (Currency)(2 + array.GetUpperBound(0) + y);
                    dict[(xCurrency, yCurrency)] = array[x, y];
                    if (array[x, y] == 0) { dict[(yCurrency, xCurrency)] = 0; }
                    else { dict[(yCurrency, xCurrency)] = 1f / array[x, y]; }
                }
            }
            return dict;
        }

        private static bool IsLoop(List<(Currency, Currency)> list)
        {
            var z = new List<(Currency, Currency)>(list);
            var first = list[0];
            var current = first;
            var previous = current;
            try
            {
                while (z.Count > 0)
                {
                    previous = current;
                    var match = z.Where(e => e.Item1 == current.Item2).First();
                    z.Remove(match);
                    current = match;
                }
            }
            catch { }
            return z.Count == 0;
        }
    }
}