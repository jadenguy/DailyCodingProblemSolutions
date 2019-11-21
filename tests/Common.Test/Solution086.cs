namespace Common
{
    public class Solution086
    {
        public static int MissingParenthesisCount(string content)
        {
            int howManyOpenUpToNow = 0;
            int howManyOpenAddedToStart = 0;
            for (int i = 0; i < content.Length; ++i)
            {
                howManyOpenUpToNow += content[i] == '(' ? 1 : -1;
                if (howManyOpenUpToNow == -1)
                {
                    howManyOpenAddedToStart += 1;
                    howManyOpenUpToNow += 1;
                }
            }
            var HowManyCloseAddedToEnd = howManyOpenUpToNow;
            return howManyOpenUpToNow + howManyOpenAddedToStart;
        }
    }
}