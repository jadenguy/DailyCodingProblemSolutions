using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution087
    {
        class Rules
        {
            public enum Relationship { N = -2, S = 2, E = 1, W = -1 }
            public class PlaceComparer : IComparer<Place>, IEqualityComparer<Place>
            {
                public int Compare(Place x, Place y) => x.PlaceName.CompareTo(y.PlaceName);
                public bool Equals(Place x, Place y) => x.PlaceName.Equals(y.PlaceName);
                public int GetHashCode(Place obj) => obj.PlaceName.GetHashCode();
            }
            public class Place
            {
                string placeName;
                Dictionary<Relationship, List<Place>> relationships;
                public string PlaceName { get => placeName; set => placeName = value; }
                public Dictionary<Relationship, List<Place>> Relationships { get => relationships; set => relationships = value; }
                public Place(string placeName)
                {
                    if (string.IsNullOrWhiteSpace(placeName)) { throw new ArgumentException("Null Placename", nameof(placeName)); }
                    var EnumValues = Enum.GetValues(typeof(Relationship)).Cast<Relationship>();
                    Relationships = EnumValues.ToDictionary(k => k, v => new List<Place>());
                    PlaceName = placeName;
                }
                public void RelateTo(char r, Place p)
                {
                    if (Enum.TryParse(r.ToString(), out Relationship r2))
                    {
                        RelateTo(r2, p);
                    }
                }
                public void RelateTo(Relationship relates, Place p)
                {
                    if (!Relationships[relates].Contains(p))
                    {
                        Relationships[relates].Add(p);
                        Relationship opposite = (Relationship)(-(int)relates);
                        p.Relationships[opposite].Add(this);
                    }
                }
                public bool Validate()
                {
                    var ret = true;
                    return ret;
                }
                public override string ToString() => this.PlaceName;
            }
            private List<Place> places = new List<Place>();
            public List<Place> Places { get => places; set => places = value; }
            public Place GetOrAddPlace(string value)
            {
                Place ret = new Place(value);
                var comparer = new PlaceComparer();
                bool v1 = !Places.Contains(ret, comparer);
                if (v1) { Places.Add(ret); }
                return ret;
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
                var l = ret.GetOrAddPlace(parts[0]);
                var r = ret.GetOrAddPlace(parts[2]);
                foreach (var direction in parts[1])
                {
                    l.RelateTo(direction, r);
                }
            }
            return ret;
        }
    }
}