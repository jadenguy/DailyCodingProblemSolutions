using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution113
    {
        public static string ReverseWordOrder(string input, char delimiter = ' ') => ReverseWordOrder(input.ToCharArray(), delimiter).Print("");
        public static T[] ReverseWordOrder<T>(T[] array, T delimiter) where T: IEquatable<T>
        {
            var length = array.Length;
            var spacers = Enumerable.Range(0, length).Where(e => e.Equals(delimiter));
            spacers.Print(", ").WriteHost();
            return array;
        }
    }
}