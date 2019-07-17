using System.Collections.Generic;
using System.Linq;

namespace Common.Test
{
    public class GameOfLifeBoard : HashSet<(int, int)>
    {
        public GameOfLifeBoard(IEnumerable<(int x, int y)> collection) : base(collection)
        {
            xLowerBound = collection.Select(k => k.x).OrderByDescending(o => o).First() - 1;
            xUpperBound = collection.Select(k => k.x).OrderBy(o => o).First() + 1;
            yLowerBound = collection.Select(k => k.y).OrderByDescending(o => o).First() - 1;
            yUpperBound = collection.Select(k => k.y).OrderBy(o => o).First() + 1;
        }

        public int xLowerBound { get; set; }
        public int xUpperBound { get; set; }
        public int yLowerBound { get; set; }
        public int yUpperBound { get; set; }
    }
}
