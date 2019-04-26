using System;
using System.Collections.Generic;

namespace Common
{
    public static class Solution15
    {
        public static T StreamElements<T>(StreamElementSelector<T> streamElementSelector, T[] array)
        {
            foreach (var item in array)
            {
                streamElementSelector.SuggestElement(item);
            }
            return streamElementSelector.Element;
            
        }
    }
}