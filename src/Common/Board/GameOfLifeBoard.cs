using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Board
{
    public class GameOfLifeBoard : HashSet<(int x, int y)>
    {
        public GameOfLifeBoard() : base() { }
        public GameOfLifeBoard(IEnumerable<(int x, int y)> collection) : base(collection) { }

        public int xLowerBound { get => this.Min(k => k.x); }
        public int xUpperBound { get => this.Max(k => k.x); }
        public int yLowerBound { get => this.Min(k => k.y); }
        public int yUpperBound { get => this.Max(k => k.y); }
        public bool Contains(int x, int y) => this.Contains((x, y));
        public void Add(int x, int y) => this.Add((x, y));
        public void Remove(int x, int y) => this.Remove((x, y));
    }
}
