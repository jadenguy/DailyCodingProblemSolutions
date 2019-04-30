using System.Collections;
using System.Collections.Generic;

namespace Common.FileSystem
{
    public class Directory : FileSystemObject, IEnumerable<FileSystemObject>
    {
        private Dictionary<string, FileSystemObject> contents = new Dictionary<string, FileSystemObject>();

        public Directory(string name) : base(name)
        {
        }

        public Directory(string name, string parentDirPath) : base(name, parentDirPath)
        {
        }

        public FileSystemObject this[string name] { get => contents[name]; }
        public void AddFSO(FileSystemObject item)
        {
            FileSystemObjectType type = FileSystemObjectType.File;
            if (item.GetType() == typeof(Directory)) { type = FileSystemObjectType.Directory; }
            AddFSO(item.Name, type);
        }
        public void AddFSO(string itemName, FileSystemObjectType type)
        {
            // string Path = base.Path + "/";
            switch (type)
            {
                case FileSystemObjectType.Directory:
                    {

                        contents.Add(itemName, new Directory(itemName, Path));
                        break;
                    }
                case FileSystemObjectType.File:
                    {
                        contents.Add(itemName, new File(itemName, Path));
                        break;
                    }
                default: { break; }
            }
        }
        public IEnumerator<FileSystemObject> GetEnumerator() => contents.Values.GetEnumerator();
        public IEnumerable<FileSystemObject> gci(bool recurse = false)
        {
            foreach (var item in contents.Values)
            {
                yield return item;

                var dir = item as Directory;
                if (recurse && dir != null)
                {
                    foreach (var subItem in dir.gci(true))
                    {
                        yield return subItem;
                    }
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => contents.GetEnumerator();
    }
}