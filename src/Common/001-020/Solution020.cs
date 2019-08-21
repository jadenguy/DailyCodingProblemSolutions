using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution020

    {
        public static int FindCommonNode(LinkedListNode a, LinkedListNode b)
        {
            LinkedListNode big;
            LinkedListNode small;
            int diff;
            int heightA = a.Height;
            int heightB = b.Height;
            diff = Math.Abs(heightA - heightB);
            if (heightA < heightB) { big = b; small = a; }
            else { big = a; small = b; }
            for (int j = 0; j < diff; j++)
            {
                big = big.Next;
            }
            bool keepGoing = true;
            int i;
            for (i = 0; i < big.Height && keepGoing; i++)
            {
                if (big.Value == small.Value) { keepGoing = false; } else { big = big.Next; small = small.Next; }
            }
            return big.Value;
        }
    }
}