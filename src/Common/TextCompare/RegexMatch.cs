namespace Common.TextCompare
{
    public class RegexMatch
    {
        public RegexMatch(string text, int startCharacter, int length, RegexRule rule = null)
        {
            this.StartCharacter = startCharacter;
            this.Length = length;
            this.Text = text;
            this.Rule = rule;
        }
        public int StartCharacter { get; set; }
        public int Length { get; set; }
        public string Text { get; set; }
        public RegexRule Rule { get; set; }
        public override string ToString() => Text;
        public static implicit operator string(RegexMatch r) => r.ToString();
        public static implicit operator RegexMatch(string s) => new RegexMatch(s, 0, s.Length);
        public bool Validate() => Rule.Test(this);
    }
}