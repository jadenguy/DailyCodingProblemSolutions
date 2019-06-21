namespace Common.Regex
{
    public class SubString
    {
        public SubString()
        {
        }

        public SubString(string text, int start, int length)
        {
            this.Text = text;
            this.StartCharacter = start;
            this.Length = length;

        }
        public string Text { get; set; }
        public int StartCharacter { get; set; }
        public int Length { get; set; }
        public override string ToString() => Text;
        public static implicit operator string(SubString r) => r.ToString();
    }

}