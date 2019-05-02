namespace Common.FileSystem
{
    public abstract class FileSystemObject
    {
        public FileSystemObject(string name) { Name = name; Path = name; }
        public FileSystemObject(string name, string parentDirPath)
        {
            Name = name;
            if (!System.String.IsNullOrWhiteSpace(parentDirPath)) { Path = parentDirPath + "/" + name; }
            else { Path = name; }
        }
        public string Name { get; set; }
        public string Path { get; set; }
        public override string ToString() => Path;
    }
}