using System;
using System.Linq;

namespace Common.IndexMath
{
    public static class IndexMath
    {
        public static int[] OneToMultiIndex(this int index, int[] sizes)
        {
            if (index > sizes.Product()) { throw new IndexOutOfRangeException("Single Dimensional Index Out Of Multi-Dimensional Range"); }
            int length = sizes.Length;
            var indexes = new int[length];
            for (int j = 0; j < length; j++)
            {
                indexes[j] = index;
                for (int k = j + 1; k < length; k++)
                {
                    indexes[j] /= sizes[k];
                }
            }
            indexes[length - 1] = index % sizes[length - 1];
            if (indexes.MultiToOneIndex(sizes) != index) { throw new Exception(); }
            return indexes;
        }
        private static int Product(this int[] sizes)
        {
            return sizes.Aggregate(1, (n, m) => n * m);
        }
        public static int MultiToOneIndex(this int[] indexes, int[] sizes)
        {
            int length = sizes.Length;
            var index = 0;
            for (int i = 0; i < length; i++)
            {
                var r = indexes[i];
                if (r >= sizes[i]) { throw new IndexOutOfRangeException("Multi-Dimensional Index Out Of Range"); }
                for (int j = i + 1; j < length; j++)
                {
                    r *= sizes[j];
                }
                index += r;
            }
            return index;
        }
    }
}