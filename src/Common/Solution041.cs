// Implement integer exponentiation. That is, implement the pow(x, y) function, where x and y are integers and returns x^y.
// Do this faster than the naive method of repeated multiplication.
// For example, pow(2, 10) should return 1024.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution041
    {
        public static IEnumerable<List<T>> FindItinerary<T>(IEnumerable<(T From, T To)> flights, T startingPoint) where T : IEquatable<T>
        {

            List<(T, T)>[] itineraries = GenerateChains(flights.ToList(), ((T From, T To) a, (T From, T To) b) => a.From.Equals(b.To)).ToArray();
            foreach (List<(T From, T To)> itinerary in itineraries)
            {
                if (itinerary.Count() == flights.Count() && itinerary.First().From.Equals(startingPoint))
                {
                    var ret = new List<T>() { startingPoint };
                    ret.AddRange(itinerary.Select(i => i.Item2));
                    yield return ret;
                }
            }
        }
        public static IEnumerable<List<(T, T)>> GenerateChains<T>(this List<(T, T)> connections, Func<(T, T), (T, T), bool> evaluator)
        {
            foreach (var item in connections)
            {
                var chain = new List<(T, T)>() { item };
                foreach (var fullChain in chain.AddLink(connections, evaluator))
                {
                    yield return fullChain;
                }
            }
        }
        public static IEnumerable<List<(T, T)>> AddLink<T>(this List<(T, T)> chain, List<(T, T)> availableLinks, Func<(T, T), (T, T), bool> evaluator)
        {
            var last = chain.Last();
            var nextLinks = availableLinks.Where(x => !chain.Contains(x)).Where(x => evaluator(x, last)).ToArray();
            if (nextLinks.Length == 0) { yield return chain; }
            else
            {
                foreach (var nextLink in nextLinks)
                {
                    var newChain = new List<(T, T)>(chain) { nextLink };
                    foreach (var nextChain in newChain.AddLink(availableLinks, evaluator))
                    {
                        yield return nextChain;
                    }
                }
            }
        }
    }
}