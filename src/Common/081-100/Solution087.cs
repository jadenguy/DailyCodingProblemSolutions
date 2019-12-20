using Common.RelativeAPlace;

namespace Common
{
    public partial class Solution087
    {

        public static bool Validate(string[] ruleSets) => Parse(ruleSets).Validate();
        private static PlaceRelationshipSet Parse(string[] ruleSets)
        {
            var ret = new PlaceRelationshipSet();
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