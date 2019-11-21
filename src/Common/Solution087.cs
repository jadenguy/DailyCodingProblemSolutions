using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution087
    {
        class Rules
        {
            public enum Direction { N = -2, S = 2, E = 1, W = -1 }

            public class Place
            {
                string placeName;
                Dictionary<Direction, List<Place>> relationships;
                public string PlaceName { get => placeName; set => placeName = value; }
                public Dictionary<Direction, List<Place>> Relationships { get => relationships; set => relationships = value; }
                public Place(string placeName)
                {
                    if (string.IsNullOrWhiteSpace(placeName)) { throw new ArgumentException("Null Placename", nameof(placeName)); }
                    var EnumValues = GetEnumValues();
                    Relationships = EnumValues.ToDictionary(k => k, v => new List<Place>());
                    PlaceName = placeName;
                }
                private static IEnumerable<Direction> GetEnumValues()
                {
                    return Enum.GetValues(typeof(Direction)).Cast<Direction>();
                }
                public void RelateTo(char directionString, Place place) => RelateTo((Direction)Enum.Parse(typeof(Direction), directionString.ToString()), place);
                public void RelateTo(Direction direction, Place place)
                {
                    Direction opposite = (Direction)(-(int)direction);
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
                public bool Validate()
                {
                    var ret = true;
                    return ret;
                }
                public string RelationshipCount()
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
            }
            private List<Place> places = new List<Place>();
            public List<Place> Places { get => places; set => places = value; }
            public Place GetOrAddPlace(string placeName)
            {
                Place place = new Place(placeName);
                IEnumerable<Place> existingPlace = Places.Where(p => p.PlaceName == placeName);
                bool v1 = !existingPlace.Any();
                if (v1) { Places.Add(place); }
                return existingPlace.First();
            }
        }
        public static bool Validate(string[] ruleSets)
        {
            var ret = false;
            var rules = Resolve(ruleSets);
            return ret;
        }
        private static Rules Resolve(string[] ruleSets)
        {
            var ret = new Rules();
            foreach (var rule in ruleSets)
            {
                var parts = rule.Split(' ');
                var a = ret.GetOrAddPlace(parts[0]);
                var b = ret.GetOrAddPlace(parts[2]);
                foreach (var direction in parts[1])
                {
                    a.RelateTo(direction, b);
                }
            }
            return ret;
        }
    }
}