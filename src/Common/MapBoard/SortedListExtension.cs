using System.Collections.Generic;
using System.Linq;

namespace Common.MapBoard
{
    static class SortedListExtension
    {
        public static Cell TakeTop(this SortedList<int, Cell> list)
        {
            var first = list.First();
            list.RemoveAt(0);
            return first.Value;
        }
        public static void AddCell(this SortedList<int, Cell> list, Cell cell) => list.Add(cell.F, cell);
    }
}