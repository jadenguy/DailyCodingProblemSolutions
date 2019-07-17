using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Board;
using static Common.Board.ConwayRules;

namespace Common
{
    public static class Solution39
    {
        public static IEnumerable<GameOfLifeBoard> PlayConway(HashSet<(int, int)> hashSet, ConwayRules rules, int rounds = int.MaxValue)
        {
            GameOfLifeBoard board = new GameOfLifeBoard(hashSet);
            bool finite = true;
            bool keepPlaying = true;
            if (rounds == int.MaxValue) { finite = false; }
            int i = 0;
            while (board.Count > 0 && i < rounds)
            {
                yield return board;
                if (keepPlaying)
                {
                    var oldBoard = board.OrderBy(k => k).ToArray();
                    keepPlaying = board.PlayARound(rules).OrderBy(k => k).ToArray() != oldBoard;
                }
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
            var actionList = new List<(LifeAction doThis, int x, int y)>();
            for (int x = xLower; x <= xUpper; x++)
            {
                for (int y = yLower; y <= yUpper; y++)
                {
                    var neighbors = board.GetNeighbors(x, y).ToArray();
                    var alive = board.Contains(x, y);
                    var doThis = rules.Apply(neighbors.Length, alive);
                    actionList.Add((doThis, x, y));
                }
            }
            foreach (var action in actionList)
            {
                switch (action.doThis)
                {
                    case LifeAction.Create:
                        board.Add(action.x, action.y);
                        break;
                    case LifeAction.Destroy:
                        board.Remove(action.x, action.y);
                        break;
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
            int xLower = Math.Min(0, board.xLowerBound);
            int xUpper = Math.Max(0, board.xUpperBound);
            int yLower = Math.Min(0, board.yLowerBound);
            int yUpper = Math.Max(0, board.yUpperBound);
            ret.AppendLine($"{xLower},{yLower}");
            for (int x = xLower; x <= xUpper; x++)
            {
                ret.AppendLine();
                ret.Append(padding);
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