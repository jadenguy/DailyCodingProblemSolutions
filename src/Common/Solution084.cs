using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Solution084
    {
        public class IslandOcean
        {
            bool[,] land;
            public IslandOcean(int xSize, int ySize) => Land = new bool[xSize, ySize];
            public bool[,] Land { get => land; set => land = value; }
            public IEnumerable<(int x, int y)> NeighborLand(int x, int y) => this.NeighborLand((x, y));
            public IEnumerable<(int x, int y)> NeighborLand((int x, int y) coordinates)
            {
                if (Land[coordinates.x, coordinates.y])
                {
                    var xLen = this.Land.GetUpperBound(0);
                    var yLen = this.Land.GetUpperBound(1);
                    var xMax = Math.Min(xLen, coordinates.x + 1);
                    var yMax = Math.Min(yLen, coordinates.y + 1);
                    var yMin = Math.Max(0, coordinates.y - 1);
                    var xMin = Math.Max(0, coordinates.x - 1);
                    for (int x = xMin; x <= xMax; x++)
                    {
                        for (int y = yMin; y <= yMax; y++)
                        {
                            if (Land[x, y]) { yield return (x, y); }
                        }
                    }
                }
            }
        }
        public static IslandOcean StringArrayToGrid(string[] array)
        {
            // throw new NotImplementedException();
            int xSize = array.Length;
            int ySize = array.FirstOrDefault().Length;
            IslandOcean islandOcean = new IslandOcean(xSize, ySize);
            for (int x = 0; x < xSize; x++)
            {
                var row = array[x];
                for (int y = 0; y < ySize; y++)
                {
                    var cell = row[y];
                    islandOcean.Land[x, y] = (cell == '1');
                }
            }
            islandOcean.Land.Print();
            return islandOcean;
        }
        public static IEnumerable<IEnumerable<(int x, int y)>> ListIslands(IslandOcean ocean)
        {
            var xLen = 1 + ocean.Land.GetUpperBound(0);
            var yLen = 1 + ocean.Land.GetUpperBound(1);
            var islands = new List<List<(int x, int y)>>();
            for (int x = 0; x < xLen; x++)
            {
                for (int y = 0; y < yLen; y++)
                {
                    var island = islands.Where(l => l.Contains((x, y))).FirstOrDefault();
                    if (island != null)
                    {
                        island.AddRange(ocean.NeighborLand(x, y));
                    }
                    else if (ocean.Land[x, y])
                    {
                        var newList = new List<(int, int)>();
                        var collection = ocean.NeighborLand(x, y);
                        newList.AddRange(collection);
                        islands.Add(newList);
                    }
                }
            }
            return islands.Select(l => l.Distinct());
        }
    }
    public static class BoolOceanExtension
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