using System.Collections.Generic;

namespace Common.MapBoard
{
    static class CellListExtension
    {
        public static Cell TakeTopCell(this List<Cell> list)
        {
            list.Sort((x, y) => x.F.CompareTo(y.F));
            var first = list[0];
            list.RemoveAt(0);
            return first;
        }
        public static void AddCell(this List<Cell> list, Cell cell)
        {
            list.Add(cell);
        }
    }
}