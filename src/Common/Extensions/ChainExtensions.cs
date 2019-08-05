using System.Collections.Generic;


namespace Common.Extensions
{
    public static class ChainExtensions
    {
        public interface IChainabilityComparer<T>
        {
            bool Chainable(T a, T b);
        }
        public static IEnumerable<T[]> GenerateChains<T>(this IEnumerable<T> connections, IChainabilityComparer<T> evaluator, bool underLength = false)
        {
            foreach (var item in connections)
            {
                var chain = new List<T>() { item };
                foreach (var fullChain in chain.AddLinks(connections, evaluator, underLength))
                {
                    yield return fullChain;
                }
            }
        }
        public static IEnumerable<T[]> AddLinks<T>(this List<T> chain, IEnumerable<T> availableLinks, IChainabilityComparer<T> evaluator, bool underLength = false)
        {
            var last = chain.FindLast(e => true);
            var otherLinks = new List<T>(availableLinks);
            otherLinks.Remove(last);
            var nextLinks = otherLinks
                .FindAll(next => evaluator.Chainable(last, next));
            if (underLength || nextLinks.Count == 0)
            {
                yield return chain.ToArray();
            }
            foreach (var nextLink in nextLinks)
            {
                var newChain = new List<T>(chain) { nextLink };
                foreach (var nextChain in newChain.AddLinks(otherLinks, evaluator, underLength))
                {
                    yield return nextChain;
                }
            }
        }
    }
}