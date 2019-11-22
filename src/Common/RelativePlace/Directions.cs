using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.RelativeAPlace
{
    public class Directions
    {
        internal class Direction
        {
            private int id;
            private string name;
            public int Id { get => id; set => id = value; }
            public string Name { get => name; set => name = value; }
            public Direction(int id, string name)
            {
                this.Name = name;
                this.Id = id;
            }
            internal Direction Opposite() => Directions.Dict[this];
            public override string ToString() => Name;
        }
        private static Dictionary<Direction, Direction> Dict;
        static Directions()
        {
            Dict = new Dictionary<Direction, Direction>();
            var n = new Direction('N', "North");
            var s = new Direction('S', "South");
            var e = new Direction('E', "East");
            var w = new Direction('W', "West");
            Pair(n, s);
            Pair(e, w);
        }
        private static void Pair(Direction a, Direction b)
        {
            if (Dict.Keys.Contains(a) || Dict.Values.Contains(a))
            { throw new ArgumentException("Direction already exists.", a.Name); }
            else if (Dict.Keys.Contains(b) || Dict.Values.Contains(b))
            { throw new ArgumentException("Direction already exists.", b.Name); }
            else
            {
                Dict.Add(a, b);
                Dict.Add(b, a);
            }
        }
        internal static IEnumerable<Direction> List => Dict.Keys;
        internal static IEnumerable<(Direction x, Direction y)> ListPairs()
        {
            var source = Directions.List.ToList();
            while (source.Count() > 0)
            {
                var a = source.FirstOrDefault();
                if (a != null)
                {
                    var b = a.Opposite();
                    source.Remove(a);
                    source.Remove(b);
                    yield return (a, b);
                }
            }
        }
        internal static Direction GetDirection(int placeCode) => Dict.Keys.Where(p => p.Id == placeCode).FirstOrDefault();
    }
}
