using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution141
    {
        public class NStack<T>
        {
            private readonly int n;
            private readonly List<T> innerList;
            private readonly int[] lengths;
            private int maxLength => lengths.Max();
            public int N { get => n; }
            public NStack(int n)
            {
                this.n = n;
                this.innerList = new List<T>();
                this.lengths = new int[this.N];
            }
            public void Push(int list, T value)
            {
                int wasMax = maxLength;
                int nIndex = lengths[list]++;
                if (nIndex == wasMax)
                {
                    for (int i = 0; i < N; i++)
                    {
                        innerList.Add(value);
                    }
                }
                else { innerList[nIndex * N + list] = value; }
            }
            public T Pop(int list)
            {
                var v = lengths[list]-- - 1;
                var v1 = v * N + list;
                var t = innerList[v1];
                return t;
            }
        }
    }
}