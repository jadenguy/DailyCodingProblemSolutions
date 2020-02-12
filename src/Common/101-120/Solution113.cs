using System;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution113
    {
        public static string ReverseWordOrder(string input, char delimiter = ' ') => ReverseWordOrderInPlace(input, delimiter);
        public static string ReverseWordOrderNewArrays(string input, char delimiter = ' ')
        {
            var rev = input.Split(new char[] { delimiter });
            rev.Reverse();
            return rev.Print(delimiter.ToString());
        }
        public static string ReverseWordOrderInPlace(string input, char delimiter = ' ') => new string(ReverseArrayDelimitedSeriesOrder(input.ToCharArray(), delimiter));
        public static T[] ReverseArrayDelimitedSeriesOrder<T>(this T[] array, T delimiter) where T : IEquatable<T>
        {
            int length = array.Count();
            array.Reverse();
            var start = 0;
            T previous = array.FirstOrDefault();
            for (int i = 0; i < length; i++)
            {
                var current = array[i];
                bool isCurrentDelimiter = current.Equals(delimiter);
                if (isCurrentDelimiter)
                {
                    if (!previous.Equals(delimiter)) { array.Reverse(start, i - start - 1); }
                    start = i + 1;
                }
                previous = current;
            }
            array.Reverse(start);
            return array;
        }
    }
}