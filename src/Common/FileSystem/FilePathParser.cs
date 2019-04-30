namespace Common.FileSystem
{
    public static class FilePathParser
    {
        public static FileSystemObject Parse(string tree)
        {
            var ret = new Directory("dir");
            var fsoList = tree.Split('\n');
            var currentDir = ret;
            var currentDepth = 0;
            for (int i = 1; i < fsoList.Length; i++)
            {
                string fso = fsoList[i];
                var fsoName = string.Empty;
                var depth = 0;
                for (int charIndex = 0; charIndex < fso.Length; charIndex++)
                {
                    char character = fso[charIndex];
                    if (character == '\t')
                    {
                        depth++;
                    }
                    else { charIndex = fso.Length; }
                }
                fsoName = fso.Substring(depth);
                FileSystemObject item;
                if (!fsoName.Contains("."))
                {
                    item = new Directory(fsoName, "unknown");
                }
                else
                {
                    item = new File(fsoName, "unknown");
                }
            }
            return ret;
        }
    }
}