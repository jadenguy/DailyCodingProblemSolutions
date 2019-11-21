using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution087
    {
        class Rules
        {
            enum Relationship
            {
                North = -2, South = 2, East = 1, West = -1
            }
            class Place
            {
                Dictionary<Relationship, List<Place>> relationships;
                public Place()
                {
                    var EnumValues = Enum.GetValues(typeof(Relationship)).Cast<Relationship>();
                    relationships = EnumValues.ToDictionary(k => k, v => new List<Place>());
                }
                public void RelateTo(Relationship r, Place p)
                {
                    relationships[r].Add(p);
                    Relationship oppositeDirection = (Relationship)(-(int)r);
                    foreach (var item in relationships[oppositeDirection])
                    {

                    }
                }
                public bool Validate()
                {
                    var ret = true;
                    return ret;
                }
            }
            Place[] p;
        }
        public static int Validate(string[] ruleSets)
        {
            var rules = Resolve(ruleSets);
            throw new NotImplementedException();
        }
        private static Rules Resolve(string[] ruleSets)
        {
            throw new NotImplementedException();
        }
    }
}