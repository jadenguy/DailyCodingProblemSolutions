using System;

namespace Common.Forex
{

    public class Currency : IEquatable<Currency>
    {
        public Currency(int id = 0, string name = "")
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Equals(Currency other) => Name.Equals(other.Name);
        public override int GetHashCode() => Name.GetHashCode();
        public override string ToString() => Name;
    }
}

