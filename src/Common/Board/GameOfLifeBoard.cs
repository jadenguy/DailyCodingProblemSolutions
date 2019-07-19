using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Board
{
    public class GameOfLifeBoard : HashSet<(int x, int y)>
    {
        public GameOfLifeBoard() : base() { }
        public GameOfLifeBoard(IEnumerable<(int x, int y)> collection) : base(collection) { }
        public int GetLowerBound(int dimension)
        {
            if (dimension == 0)
            { return this.DefaultIfEmpty().Min(k => k.x); }
            else if (dimension == 1)
            { return this.DefaultIfEmpty().Min(k => k.y); }
            else { return 0; }
        }
        public int GetUpperBound(int dimension)
        {
            if (dimension == 0)
            { return this.DefaultIfEmpty().Max(k => k.x); }
            else if (dimension == 1)
            { return this.DefaultIfEmpty().Max(k => k.y); }
            else { return 0; }
        }
        public bool Contains(int x, int y) => this.Contains((x, y));
        public void Add(int x, int y) => this.Add((x, y));
        public void Remove(int x, int y) => this.Remove((x, y));
    }
}
