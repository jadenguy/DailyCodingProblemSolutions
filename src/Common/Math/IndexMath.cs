using System;
using System.Linq;

namespace Common.IndexMath
{
    public static class IndexMath
    {
        public static int[] OneToMultiIndex(this int i, int[] sizes)
        {
            if (i > sizes.Product()) { throw new IndexOutOfRangeException("Single Dimensional Index Out Of Multi-Dimensional Range"); }
            int length = sizes.Length;
            var ret = new int[length];
            for (int j = 0; j < length; j++)
            {
                ret[j] = i;
                for (int k = j + 1; k < length; k++)
                {
                    ret[j] /= sizes[k];
                }
            }
            ret[length - 1] = i % sizes[length - 1];
            return ret;
        }
        private static int Product(this int[] sizes)
        {
            return sizes.Aggregate(1, (n, m) => n * m);
        }
        public static int MultiToOneIndex(this int[] indexes, int[] sizes)
        {
            int length = sizes.Length;
            var ret = 0;
            for (int i = 0; i < length; i++)
            {
                var r = indexes[i];
                if (r >= sizes[i]) { throw new IndexOutOfRangeException("Multi-Dimensional Index Out Of Range"); }
                for (int j = i + 1; j < length; j++)
                {
                    r *= sizes[j];
                }
                ret += r;
            }
            return ret;
        }
    }
}