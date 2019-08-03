using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class ChainExtensions
    {
        public interface IChainabilityComparer<T>
        {
            bool Chainable( T a, T b);
        }
        public static IEnumerable<T[]> GenerateChains<T>(this List<T> connections, IChainabilityComparer<T> evaluator)
        {
            foreach (var item in connections)
            {
                var chain = new List<T>() { item };
                foreach (var fullChain in chain.AddLink(connections, evaluator))
                {
                    yield return fullChain;
                }
            }
        }
        public static IEnumerable<T[]> AddLink<T>(this List<T> chain, List<T> availableLinks, IChainabilityComparer<T> evaluator)
        {
            var last = chain.Last();
            var nextLinks = availableLinks
                .Where(next => !chain.Contains(next))
                .Where(next => evaluator.Chainable(last,next))
                .ToArray();
            if (nextLinks.Length == 0) { yield return chain.ToArray(); }
            else
            {
                foreach (var nextLink in nextLinks)
                {
                    var newChain = new List<T>(chain) { nextLink };
                    foreach (var nextChain in newChain.AddLink(availableLinks, evaluator))
                    {
                        yield return nextChain;
                    }
                }
            }
        }
    }
}