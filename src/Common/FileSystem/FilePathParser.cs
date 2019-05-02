using System.Collections.Generic;

namespace Common.FileSystem
{
    public static class FilePathParser
    {
        public static FileSystemObject Parse(string tree)
        {
            Directory ret = new Directory("root");
            var fsoList = tree.Split('\n');
            var currentPath = new List<Directory>();
            foreach (string fsoEntry in fsoList)
            {
                var depth = 0;
                for (int charIndex = 0; charIndex < fsoEntry.Length; charIndex++)
                {
                    char character = fsoEntry[charIndex];
                    if (character == '\t') { depth++; }
                    else { charIndex = fsoEntry.Length; }
                }

                var fsoName = fsoEntry.Substring(depth);
                var fso = FileSystemObjectGenerator.CreateFSO(fsoName);
                var fsoAsDir = fso as Directory;
                if (depth == 0)
                {
                    currentPath.Add(fsoAsDir);
                    ret = fsoAsDir;
                }
                else
                {
                    currentPath[depth - 1].AddFSO(fso);
                    if (fsoAsDir != null)
                    {
                        if (depth != currentPath.Count) { currentPath.RemoveRange(depth, currentPath.Count - depth); }
                        currentPath.Add(fsoAsDir);
                    }
                }
            }
            return ret;
        }
    }
}