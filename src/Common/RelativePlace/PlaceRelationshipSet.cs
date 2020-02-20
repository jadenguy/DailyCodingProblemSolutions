using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Extensions;

namespace Common.RelativeAPlace
{
    public class PlaceRelationshipSet
    {
        public class Place
        {
            string placeName;
            Dictionary<Directions.Direction, List<Place>> relationships;
            internal string PlaceName { get => placeName; set => placeName = value; }
            internal Dictionary<Directions.Direction, List<Place>> Relationships { get => relationships; set => relationships = value; }
            internal Place(string placeName)
            {
                if (string.IsNullOrWhiteSpace(placeName)) { throw new ArgumentException("Null Placename", nameof(placeName)); }
                var directions = Directions.List;
                Relationships = directions.ToDictionary(k => k, v => new List<Place>());
                PlaceName = placeName;
            }
            internal void RelateTo(char directionString, Place place) => RelateTo(Directions.GetDirection(directionString), place);
            internal void RelateTo(Directions.Direction direction, Place place)
            {
                var opposite = direction.Opposite();
                if (this != place && !Relationships[direction].Contains(place))
                {
                    Relationships[direction].Add(place);
                    place.RelateTo(opposite, this);
                    foreach (var otherPlace in Relationships[opposite])
                    {
                        otherPlace.RelateTo(direction, place);
                    }
                }
            }
            internal bool Validate()
            {
                return Directions.ListPairs().Select(direction =>
                    {
                        var aList = new HashSet<Place>(Relationships[direction.x]);
                        var bList = new HashSet<Place>(Relationships[direction.y]);
                        IEnumerable<Place> common = aList.Intersect(bList);
                        bool anyCommon = common.Any();
                        if (anyCommon)
                        {
                            var message = "Vaildation Failed:" + string.Join($" is {direction.x} and {direction.y} of ", common.Select(p => p.PlaceName));
                            message.WriteHost();
                        }
                        return !anyCommon;
                    }
                ).All(r => r);
            }
            internal string RelationshipCount()
            {
                var ret = "";
                foreach (var item in Relationships)
                {

                    ret += $"{item.Key}: {item.Value.Count},";
                }
                ret += $"#: {Relationships.Values.Sum(v => v.Count)}";
                return ret;
            }
            public override string ToString() => PlaceName + " " + RelationshipCount();
            public string Print(bool toConsole = true)
            {
                var ret = new StringBuilder();
                foreach (var direction in Relationships)
                {
                    foreach (var place in direction.Value)
                    {
                        ret.Append(this.PlaceName);
                        ret.Append(" is ");
                        ret.Append(direction.Key);
                        ret.Append(" of ");
                        ret.AppendLine(place.PlaceName);
                    }
                }
                if (toConsole)
                {
                    ret.WriteHost();
                }
                return ret.ToString();
                ;
            }
            // internal bool Validate() => Places.Select(p => p.Validate()).All(v => v);
            private List<Place> places = new List<Place>();
            internal List<Place> Places { get => places; set => places = value; }
            internal Place GetOrAddPlace(string placeName)
            {
                if (!Places.Any(p => p.PlaceName == placeName)) { Places.Add(new Place(placeName)); }
                return Places.Where(p => p.PlaceName == placeName).First();
            }
        }
        internal bool Validate() => Places.Select(p => p.Validate()).All(v => v);
        private List<Place> places = new List<Place>();
        internal List<Place> Places { get => places; set => places = value; }
        internal Place GetOrAddPlace(string placeName)
        {
            if (!Places.Any(p => p.PlaceName == placeName)) { Places.Add(new Place(placeName)); }
            return Places.Where(p => p.PlaceName == placeName).First();
        }
    }
}