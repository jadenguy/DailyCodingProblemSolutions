using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Board;

namespace Common
{
    public static class Solution39
    {
        public static IEnumerable<GameOfLifeBoard> PlayConway(HashSet<(int, int)> hashSet, ConwayRules rules, int rounds = int.MaxValue)
        {
            GameOfLifeBoard board = new GameOfLifeBoard(hashSet);
            bool finite = true;
            if (rounds == int.MaxValue) { finite = false; }
            int i = 0;
            while (board.Count > 0 && i < rounds)
            {
                yield return board;
                board.PlayARound(rules);
                if (finite) { i++; }
            }
            yield return board;
        }
        public static GameOfLifeBoard PlayARound(this GameOfLifeBoard board, ConwayRules rules)
        {
            int xLower = board.xLowerBound - 1;
            int xUpper = board.xUpperBound + 1;
            int yLower = board.yLowerBound - 1;
            int yUpper = board.yUpperBound + 1;
            for (int x = xLower; x <= xUpper; x++)
            {
                for (int y = yLower; y <= yUpper; y++)
                {
                    var neighbors = board.GetNeighbors(x, y).ToArray();
                    var alive = board.Contains(x, y);
                    switch (neighbors.Length)
                    {
                        case 0:
                            if (alive) { board.Remove(x, y); }
                            break;
                        case 1:
                            if (alive) { board.Remove(x, y); }
                            break;
                        case 2:
                            break;
                        case 3:
                            if (!alive) { board.Add(x, y); }
                            break;
                        default:
                            if (alive) { board.Remove(x, y); }
                            break;
                    }
                }
            }
            return board;
        }
        [System.Diagnostics.DebuggerStepThrough]
        public static string Display(this GameOfLifeBoard board)
        {
            if (board.Count == 0) { return ""; }
            var ret = new StringBuilder();
            var padding = " ";
            for (int x = board.xLowerBound; x <= board.xUpperBound; x++)
            {
                ret.AppendLine();
                ret.Append(padding);
                int yLower = board.yLowerBound;
                int yUpper = board.yUpperBound;
                for (int y = yLower; y <= yUpper; y++)
                {
                    if (board.Contains(x, y)) { ret.Append("*"); }
                    else { ret.Append("."); }
                    ret.Append(padding);
                }
                ret.Append(padding);
            }
            ret.AppendLine();
            return ret.ToString();
        }
    }
}