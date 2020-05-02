using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution141
    {
        public class TriStack<T>
        {
            private List<T> innerList;
            private int[] lengths;
            private int maxLength => lengths.Max();
            public TriStack()
            {
                this.innerList = new List<T>();
                this.lengths = new int[3];
            }
            public void Push(int list, T value)
            {
                int wasMax = maxLength;
                int triIndex = lengths[list]++;
                if (triIndex == wasMax)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        innerList.Add(value);
                    }
                }
                else { innerList[triIndex * 3 + list] = value; }
            }
            public T Pop(int list)
            {
                int v = lengths[list]--;
                return innerList[v * 3 + list];
            }
        }
    }
}