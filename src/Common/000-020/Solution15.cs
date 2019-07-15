using System;
using System.Collections.Generic;
using Common.RandomSelector;

namespace Common
{
    public static class Solution15
    {
        public static T StreamElements<T>(StreamElementSelector<T> streamElementSelector, IEnumerable<T> array)
        {
            foreach (var item in array)
            {
                streamElementSelector.SuggestElement(item);
            }
            return streamElementSelector.Element;
            
        }
    }
}