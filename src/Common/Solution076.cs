using System;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution076
    {
        public static int MinimumRemovedColumns(string[] rows)
        {
            int rowCount = rows.Length;
            int[][] ret = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                var row = rows[i];
                int columnCount = row.Length;
                ret[i] = new int[columnCount];
                for (int j = 0; j < columnCount - 1; j++)
                {
                    var column = row[j];
                    var furtherRows = row.Skip(j + 1);
                    var l = furtherRows.Where(m => m.CompareTo(column) < 0);
                    System.Diagnostics.Debug.WriteLine(row.Print(","));
                    System.Diagnostics.Debug.WriteLine(column);
                    System.Diagnostics.Debug.WriteLine(furtherRows.Print("=>"));
                    System.Diagnostics.Debug.WriteLine(l.Print("-"));
                    ret[i][j] = l.Count();
                    if (l.Count() > 0)
                    {
                        System.Console.WriteLine("This");
                    }
                }
            }
            return 0;
        }
    }
}