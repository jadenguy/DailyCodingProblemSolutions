using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution076
    {
        public static int MinimumRemovedColumnsForRowOrder(string[] rows)
        {
            int rowCount = rows.Length;
            var ret = Enumerable.Range(0, rowCount).ToDictionary(k => k, v => false);
            for (int i = 0; i < rowCount; i++)
            {
                var row = rows[i];
                int columnCount = row.Length;
                System.Diagnostics.Debug.WriteLine(row.Print(","));
                for (int j = 1; j < columnCount; j++)
                {
                    var column = row[j];
                    var previous = row.Take(j);
                    var greaterThan = previous.Where(m => m.CompareTo(column) > 0);
                    System.Diagnostics.Debug.WriteLine(column, "current");
                    System.Diagnostics.Debug.WriteLine(previous.Print("=>") + "=>" + column, "previous columns");
                    System.Diagnostics.Debug.WriteLine(greaterThan.Print(","), "inversions");
                    System.Diagnostics.Debug.WriteLine("");
                    if (greaterThan.Count() > 0)
                    {
                        System.Diagnostics.Debug.WriteLine("This");
                        ret[i] = true;
                    }
                }
                System.Diagnostics.Debug.WriteLine("");
            }
            return ret.Values.Where(r => r).Count();
        }
        public static int MinimumRemovedColumns(string[] rows)
        {
            int rowCount = rows.Length;
            int columnCount = rows[0].Length;
            var last = rows[0][0];
            var ret = new List<string>();
            for (int i = 0; i < columnCount; i++)
            {
                var text = string.Empty;
                for (int j = 0; j < rowCount; j++)
                {
                    text += rows[j][i];
                }
                ret.Add(text);
            }
            return MinimumRemovedColumnsForRowOrder(ret.ToArray());
        }
    }
}