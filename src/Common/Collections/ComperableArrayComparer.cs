using System;
using System.Collections.Generic;

namespace Common
{
    public class ComperableArrayComparer<T> : IComparer<T[]> where T : IComparable<T>
    {
        public ComperableArrayComparer()
        {
        }

        public int Compare(T[] x, T[] y)
        {
            if (y == null) { return 0; }
            if (x.Length != y.Length) { return x.Length.CompareTo(y.Length); }
            for (int i = 0; i < x.Length; i++)
            {
                var a = x[i];
                var b = y[i];
                var c = a.CompareTo(b);
                if (c != 0) { return c; }
            }
            return 0;
        }
    }
}