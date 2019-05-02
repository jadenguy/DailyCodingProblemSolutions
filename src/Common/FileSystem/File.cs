namespace Common.FileSystem
{
    internal class File : FileSystemObject
    {
        public File(string name) : base(name) { }
        public File(string name, string path) : base(name, path) { }
    }
}