using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common.Test
{
    public class Solution037

    {
        public static IEnumerable<T[]> PowerSet<T>(IEnumerable<T> input)
        {
            var array = input.ToArray();
            int length = array.Length;
            int square = (int)Math.Pow(2, length);
            for (int bitMask = 0; bitMask < square; bitMask++)
            {
                var ret = new List<T>();
                for (int bitPosition = 0; bitPosition <= Math.Sqrt(bitMask); bitPosition++)
                {
                    var bitValue = (int)Math.Pow(2, bitPosition);
                    if ((bitValue & bitMask) == bitValue) { ret.Add(array[bitPosition]); }
                }
                yield return ret.ToArray();
            }
        }
    }
}