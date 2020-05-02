namespace Common
{
    public static class Solution142
    {
        public static bool IsBalanced(string input)
        {
            var balance = 0;
            var wildcard = 0;
            foreach (var letter in input)
            {
                switch (letter)
                {
                    case '(':
                        balance++;
                        break;
                    case ')':
                        balance--;
                        break;
                    case '*':
                        wildcard++;
                        break;
                    default:
                        break;
                }
                if (balance < 0)
                {
                    wildcard--;
                    if (wildcard < 0)
                    {
                        wildcard--;
                        break;
                    }
                    else { balance++; }
                }
            }
            return balance <= wildcard;
        }
    }
}