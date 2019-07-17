using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Test
{
    public static  class Solution39
    {
        public static IEnumerable<GameOfLifeBoard> ConwaysGame(HashSet<(int, int)> hashSet)
        {
            yield return new GameOfLifeBoard(hashSet);
        }
        public static string Display(this GameOfLifeBoard board)
        {
            var ret = new StringBuilder();
            for (int x = board.xLowerBound; x <= board.xUpperBound; x++)
            {
                ret.AppendLine();
                for (int y = board.yLowerBound; y <= board.yUpperBound; y++)
                {
                    if
                    (board.Contains((x, y)))
                    {
                        ret.Append("X ");
                    }
                    else { ret.Append("_ "); }
                }
                ret.AppendLine();
            }
            return ret.ToString();
        }
    }
}