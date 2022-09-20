using System;
using System.Collections;
using static System.Console;
using static System.Threading.Thread;
using System.Collections.Generic;

namespace SubOS
{
    public class VFS
    {
        public class Disk
        {
            readonly public char letter;
            readonly public string name;
            readonly public Dir root;

            public Disk(char letter, string name, Dir root)
            {
                this.letter = letter;
                this.name = name;
                this.root = root;
            }
        }
        public class Dir
        {
            public string name;
            public List<Dir> dirs = new();
            public List<_File> files = new();
            readonly bool isRoot = false;
            readonly bool closed = false;

            public Dir(string name)
            {
                this.name = name;
            }
            public Dir(string name, bool isRoot, bool closed)
            {
                this.name = name;
                this.isRoot = isRoot;
                this.closed = closed;
            }
            public Dir(string name, bool closed)
            {
                this.name = name;
                this.closed = closed;
            }
        }
        public class _File
        {
            public string name = "file";
            public string? type;
            readonly bool closed = false;

            public _File(string name, string type, bool closed)
            {
                this.name = name;
                this.type = type;
                this.closed = closed;
            }

            public _File(string name)
            {
                this.name = name;
            }
            public _File(string name, string type)
            {
                this.name = name;
                this.type = type;
            }
        }
        public List<Disk> disks = new();
        public static Dir FindDirByFullName(Dir dir, string dirName)
        {
            foreach (Dir fDir in dir.dirs)
            {
                if (fDir.name == dirName)
                {
                    return fDir;
                }
            }
            return null;
        }
        public static Dir[] FindDirsByName(Dir dir, string dirName)
        {
            List<Dir> dirs = new();
            foreach (Dir dirF in dir.dirs!)
            {
                if(dirF.name == dirName)
                {
                    dirs.Add(dirF);
                }
            }
            return dirs.ToArray();
        }
        public static void MD(Dir dir, string name)
        {
            if (FindDirByFullName(dir, name) == null)
            {
                dir.dirs.Add(new Dir(name));
            }
            else
            {
                WriteLine("Folder with this name is already exists");
            }
        }
        public static void MF(Dir dir, string name, string type)
        {
            /*if (FindDirByFullName(dir, name) == null)
            {*/
                dir.files.Add(new _File(name, type));
            /*}
            else
            {
                WriteLine("Folder with this name is already exists");
            }*/
        }
        public static void DIR(Dir dir)
        {
            foreach (Dir Fdir in dir.dirs)
            {
                Write(Fdir.name.ToUpper());
                SetCursorPosition(27, CursorTop);
                WriteLine("DIR");
            }
            foreach (_File file in dir.files)
            {
                Write(file.name.ToUpper());
                SetCursorPosition(27, CursorTop);
                if (file.type != null) { WriteLine(file.type.ToUpper()); }
                else { WriteLine("NONE"); }
            }
        }
    }
}
