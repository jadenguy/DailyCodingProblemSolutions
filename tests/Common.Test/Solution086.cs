namespace Common
{
    public class Solution086
    {
        public static int MissingParenthesisCount(string content)
        {
            int currentOpenness = 0;
            int howManyOpenAddedToStart = 0;
            for (int i = 0; i < content.Length; ++i)
            {
                if (content[i] == '(') { currentOpenness++; }
                if (content[i] == ')')
                {
                    if (currentOpenness > 0) { currentOpenness--; }
                    else { howManyOpenAddedToStart += 1; }
                }
            }
            var howManyCloseAddedToEnd = currentOpenness;
            var newContent = new string('(', howManyOpenAddedToStart) + content + new string(')', howManyCloseAddedToEnd);
            
            return howManyOpenAddedToStart + howManyCloseAddedToEnd;
        }
    }
}