using System;

namespace Common.FileSystem
{
    public class FileSystemObjectGenerator
    {
        public static FileSystemObject CreateFSO(string name, string parentPath = "")
        {
            FileSystemObject ret;
            if (name.Contains(".")) { ret = new File(name, parentPath); }
            else { ret = new Directory(name, parentPath); }
            return ret;
        }
    }
}