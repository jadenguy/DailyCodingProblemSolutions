using System;
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
        public IEnumerator<FileSystemObject> GetEnumerator() => contents.Values.GetEnumerator();
        public IEnumerable<FileSystemObject> gci(bool recursive = false)
        {
            foreach (var item in contents.Values)
            {
                yield return item;

                var dir = item as Directory;
                if (recursive && dir != null)
                {
                    foreach (var subItem in dir.gci(true))
                    {
                        yield return subItem;
                    }
                }
            }
        }
        public void AddFSO(FileSystemObject fso)
        {
            fso.Path = this.Path + '/' + fso.Name;
            contents.Add(fso.Name, fso);
        }
        IEnumerator IEnumerable.GetEnumerator() => contents.GetEnumerator();
        public void AddFSO(string v)
        {
            var fso = FileSystemObjectGenerator.CreateFSO(v, Path);
            contents.Add(v, fso);
        }
    }
}