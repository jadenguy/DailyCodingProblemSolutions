using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution041
    {
        public static IEnumerable<List<T>> FindItineraries<TTuple,T>(IEnumerable<TTuple> flights, T startingPoint) where T : IEquatable<T> where TTuple : Tuple<T,T>
        {
            var flightList = flights.OrderBy(t => t.Item2).OrderBy(f => f.Item1).ToList();
            tupleChainEvaluator<TTuple, T> evaluator = new tupleChainEvaluator<TTuple, T>();
            var itineraries = flightList.GenerateChains(evaluator).ToArray();
            foreach (var itinerary in itineraries)
            {
                if (itinerary.Count() == flights.Count() && itinerary.First().Item1.Equals(startingPoint))
                {
                    var ret = new List<T>() { startingPoint };
                    ret.AddRange(itinerary.Select(i => i.Item2));
                    yield return ret;
                }
            }
        }
    }
    public class tupleChainEvaluator<TTuple, TInstance> : ChainExtensions.IChainabilityComparer<TTuple> where TTuple : Tuple<TInstance,TInstance> where TInstance : IEquatable<TInstance>
    {
        public bool Chainable(TTuple a, TTuple b)
        {
            return a.Item2.Equals (b.Item1);
        }
    }
}