// Given a pivot x, and a list lst, partition the list into three parts.
// *	The first part contains all elements in lst that are less than x
// *	The second part contains all elements in lst that are equal to x
// *	The third part contains all elements in lst that are larger than x
// Ordering within a part can be arbitrary.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Test
{
    internal class Solution143
    {
        internal static IEnumerable<IEnumerable<int>> Partition(int x, int[] lst)
        {
            return new[] { lst.Where(n => n < x)
                    ,lst.Where(n => n== x)
                    ,lst.Where(n => n > x)
                };
        }
    }
}