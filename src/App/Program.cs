using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // FindResults();
            return 0;
        }
        private static void FindResults()
        {
            var letters = new string[] {
                "TACHYONS",
                " NUDGED ",
                " HAPPIER",
                "ESTIMATE",
                " GENERIC",
                " VAULTER",
                "  STEADY",
                "EXPORTER"
            };
            var board = new int[8, 8];
            board[1, 0] = -1;
            board[1, 7] = -1;
            board[2, 0] = -1;
            board[4, 0] = -1;
            board[5, 0] = -1;
            board[6, 0] = -1;
            board[6, 1] = -1;
            var shortT = Common.Solution064.KnightTourFrom((int[,])board.Clone(), (0, 0), 65 - 9).Where(b => b[7, 7] == 64);
            var longT = Common.Solution064.KnightTourFrom((int[,])board.Clone(), (0, 0), 65 - 11).Where(b => b[7, 7] == 64);
            var shortE = Common.Solution064.KnightTourFrom((int[,])board.Clone(), (7, 0), 65 - 9).Where(b => b[0, 7] == 64);
            var longE = Common.Solution064.KnightTourFrom((int[,])board.Clone(), (7, 0), 65 - 11).Where(b => b[0, 7] == 64);
            var s = shortE.Union(shortT).Union(longE).Union(longT);
            foreach (var sol in s)
            {
                var places = new List<(int, int, int)>();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        int v = sol[i, j];
                        var letterIndex = (v, i, j);
                        if (v > 0) { places.Add(letterIndex); }
                    }
                }
                var word = places.OrderBy(f => f.Item1).Select(l => letters[l.Item2][l.Item3]).ToArray();
                System.Console.WriteLine(string.Join("", word));
            }
        }
    }
}
