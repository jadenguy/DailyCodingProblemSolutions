using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Board;
using Common.RandomSelector;
using static Common.Board.ConwayRules;

namespace Common
{
    public static class Solution039

    {
        public static IEnumerable<GameOfLifeBoard> PlayConway(IEnumerable<(int, int)> initial, ConwayRules rules, int rounds = int.MaxValue, int seed = 0)
        {
            var select = new StreamElementSelector<GameOfLifeBoard>(seed);
            GameOfLifeBoard oldBoard, board = new GameOfLifeBoard(initial);
            var keepPlaying = true;
            int i = 0;
            var reportDone = false;
            do
            {
                yield return board;
                if (keepPlaying && board.Count > 0)
                {
                    oldBoard = new GameOfLifeBoard(board); //clone board to old before playing
                    keepPlaying = !board.PlayARound(rules).SetEquals(oldBoard);
                    reportDone = !keepPlaying;
                }
                else if (reportDone)
                {
                    System.Diagnostics.Debug.WriteLine(i, "rounds");
                    reportDone = false;
                }
                if (rounds != int.MaxValue) { i++; }
            } while (i <= rounds);

        }
        public static GameOfLifeBoard PlayARound(this GameOfLifeBoard board, ConwayRules rules)
        {
            int xLower = board.GetLowerBound(0) - 1;
            int xUpper = board.GetUpperBound(0) + 1;
            int yLower = board.GetLowerBound(1) - 1;
            int yUpper = board.GetUpperBound(1) + 1;
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
            var ret = new StringBuilder();
            var padding = " ";
            int xLower = Math.Min(0, board.GetLowerBound(0));
            int yLower = Math.Min(0, board.GetLowerBound(1));
            int xUpper = Math.Max(0, board.GetUpperBound(0));
            int yUpper = Math.Max(0, board.GetUpperBound(1));
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