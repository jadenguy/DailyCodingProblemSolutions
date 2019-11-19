using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Solution084
    {
        public class IslandBoard
        {
            bool[,] land;
            public IslandBoard(int xSize, int ySize) => Land = new bool[xSize, ySize];
            public bool[,] Land { get => land; set => land = value; }
            public IEnumerable<(int x, int y)> Neighbors((int x, int y) coordinates)
            {
                var xUpper = 1 + this.Land.GetUpperBound(0);
                var yUpper = 1 + this.Land.GetUpperBound(1);
                var xMax = Math.Min(xUpper, coordinates.x + 1);
                var yMax = Math.Min(yUpper, coordinates.y + 1);
                var yMin = Math.Max(0, coordinates.y - 1);
                var xMin = Math.Max(0, coordinates.x - 1);
                for (int x = xMin; x < xMax; x++)
                {
                    for (int y = yMin; y < yMax; y++)
                    {
                        if (Land[x, y]) { yield return (x, y); }
                    }
                }
            }
        }
        public static IslandBoard StringArrayToGrid(string[] array)
        {
            // throw new NotImplementedException();
            int xSize = array.Length;
            int ySize = array.FirstOrDefault().Length;
            IslandBoard islandBoard = new IslandBoard(xSize, ySize);
            for (int x = 0; x < xSize; x++)
            {
                var row = array[x];
                for (int y = 0; y < ySize; y++)
                {
                    var cell = row[y];
                    islandBoard.Land[x, y] = (cell == '1');
                }
            }
            islandBoard.Land.Print();
            return islandBoard;
        }
        public static int CountIslands(IslandBoard board)
        {
            var ret = 0;
            return ret;
        }
    }
    public static class BoolBoardExtension
    {
        public static string Print(this bool[,] Land, bool output = true)
        {
            var ret = new StringBuilder();
            for (int x = 0; x <= Land.GetUpperBound(0); x++)
            {
                ret.AppendLine();
                if (Land[x, 0]) { ret.Append("X"); } else { ret.Append("_"); }
                for (int y = 1; y <= Land.GetUpperBound(1); y++)
                {
                    ret.Append("|");
                    if (Land[x, y]) { ret.Append("X"); } else { ret.Append("_"); }
                }
            }
            if (output)
            {
                System.Console.WriteLine(ret.ToString());
                System.Diagnostics.Debug.WriteLine(ret.ToString());
            }
            return ret.ToString();
        }
    }
}

