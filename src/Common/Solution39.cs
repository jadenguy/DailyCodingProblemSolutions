using System;
using System.Collections.Generic;
using System.Text;
using Common.Board;

namespace Common
{
    public static class Solution39
    {
        public static IEnumerable<GameOfLifeBoard> PlayConway(HashSet<(int, int)> hashSet, int rounds = int.MaxValue)
        {
            GameOfLifeBoard board = new GameOfLifeBoard(hashSet);
            bool finite = true;
            if (rounds == int.MaxValue) { finite = false; }
            int i = 0;
            do
            {
                yield return board;
                board.PlayARound();
                if (finite) { i++; }
            } while (i <= rounds);
        }
        public static GameOfLifeBoard PlayARound(this GameOfLifeBoard board)
        {
            for (int x = board.xLowerBound - 1; x <= board.xUpperBound + 1; x++)
            {
                for (int y = board.yLowerBound - 1; y <= board.yUpperBound + 1; y++)
                {
                    var cell = board.Contains((x, y));
                }
            }
            return board;
        }
        public static string Display(this GameOfLifeBoard board)
        {
            var ret = new StringBuilder();
            var padding = " ";
            for (int x = board.xLowerBound; x <= board.xUpperBound; x++)
            {
                ret.AppendLine();
                ret.Append(padding);
                for (int y = board.yLowerBound; y <= board.yUpperBound; y++)
                {
                    if (board.Contains((x, y))) { ret.Append("*"); }
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