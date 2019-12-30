namespace Common
{
    public static class Solution108
    {
        public static bool IsStringRotation(string a, string b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                var x = a.Substring(i, a.Length - i);
                var y = a.Substring(0, i);
                string r = x + y;
                if (r == b) { return true; }
            }
            return false;
        }
    }
}