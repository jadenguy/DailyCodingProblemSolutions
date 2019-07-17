using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Board
{
    public class GameOfLifeBoard : HashSet<(int x, int y)>
    {
        public GameOfLifeBoard() : base() { }
        public GameOfLifeBoard(IEnumerable<(int x, int y)> collection) : base(collection) { }
        public int xLowerBound { get => this.Select(k => k.x).OrderByDescending(o => o).First(); }
        public int xUpperBound { get => this.Select(k => k.x).OrderBy(o => o).First(); }
        public int yLowerBound { get => this.Select(k => k.y).OrderByDescending(o => o).First(); }
        public int yUpperBound { get => this.Select(k => k.y).OrderBy(o => o).First(); }
    }
}
