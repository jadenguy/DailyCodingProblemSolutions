namespace Common.TextCompare
{
    public class CharMatch
    {
        public CharMatch(char letter, int leftTextIndex, int rightTextIndex)
        {
            Letter = letter;
            LeftTextIndex = leftTextIndex;
            RightTextIndex = rightTextIndex;
        }
        public char Letter { get; set; }
        public int LeftTextIndex { get; set; }
        public int RightTextIndex { get; set; }
        public override string ToString() => $"{Letter} {LeftTextIndex} {RightTextIndex}";
    }
}