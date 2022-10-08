using System;
using System.Collections;
using static System.Console;
using static System.Threading.Thread;
using System.Collections.Generic;
using static SubOS.VFS;
using System.IO;
using System.Text.Json;

#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
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
            public readonly Dir? parent;
            public readonly char diskLetter;
            readonly bool isRoot = false;
            readonly bool closed = false;
            public readonly string path;

            public Dir(string name, Dir? parent, char diskLetter, bool isRoot, bool closed)
            {
                this.name = name;
                this.parent = parent;
                this.diskLetter = diskLetter;
                this.isRoot = isRoot;
                this.closed = closed;
                path = diskLetter + @":\";
            }

            public Dir(string name, Dir parent, char diskLetter)
            {
                this.name = name;
                this.parent = parent;
                this.diskLetter = diskLetter;
                path = parent.path + name + @"\";
            }

            public Dir(string name, Dir parent, char diskLetter, bool closed)
            {
                this.closed = closed;
                this.name = name;
                this.parent = parent;
                this.diskLetter = diskLetter;
                path = parent.path + name + @"\";
            }

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
            /// <summary>
            /// Only for non-method creating of instance
            /// </summary>
            public Dir()
            {
        }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        }
        public class _File
        {
            public string name = "file";
            public string? type;
            readonly bool closed = false;
            readonly string path;
            readonly Dir parent;
            readonly public bool exe;

            public _File(Dir parent, string name, string type, bool closed, bool exe)
            {
                this.name = name;
                this.type = type;
                this.closed = closed;
                this.parent = parent;
                path = parent.path + name + @"\";
                this.exe = exe;
            }

            public _File(Dir parent, string name, bool exe)
            {
                this.name = name;
                this.parent = parent;
                path = parent.path + name + @"\";
                this.exe = exe;
            }
            public _File(Dir parent, string name, string type, bool exe)
            {
                this.name = name;
                this.type = type;
                this.parent = parent;
                path = parent.path + name + @"\";
                this.exe = exe;
            }
        }
        public List<Disk> disks = new();
        public enum DirDisplayType
        {
            DOS = 0,
            UNIX = 1,
            LIST = 2
        }
        public static Dir FindDirByName(Dir dir, string dirName)
        {
            foreach (Dir fDir in dir.dirs) if (fDir.name.ToUpper() == dirName.ToUpper()) return fDir;
            return null;
        }
        public static _File FindFileByName(Dir dir, string fileName)
        {
            foreach (_File fFile in dir.files) if (fFile.name.ToUpper() == fileName.ToUpper()) return fFile;
            return null;
        }
        public static void MD(Dir dir, string name)
        {
            if (FindDirByName(dir, name) == null)
            {
                dir.dirs.Add(new Dir(name, dir, dir.diskLetter));
            }
            else
            {
                WriteLine("Folder with this name is already exists");
            }
        }
        public static void MF(Dir dir, string name, string type, bool exe)
        {
            /*if (FindDirByName(dir, name) == null)
            {*/
                dir.files.Add(new _File(dir, name, type, exe));
            /*}
            else
            {
                WriteLine("Folder with this name is already exists");
            }*/
        }
        public static void DIR(Dir dir, DirDisplayType type)
        {
            foreach (Dir Fdir in dir.dirs)
            {
                string output = Fdir.name.ToUpper();
                while (output.Length < 26)
                {
                    output = output + ".";
                }
                output = output + "DIR";
                WriteLine(output);
            }
            foreach (_File file in dir.files)
            {
                string output = file.name.ToUpper();
                while (output.Length < 26)
                {
                    output = output + ".";
                }
                if(file.type != null)
                {
                    output = output + file.type.ToUpper();
                }
                else
                {
                    output = output + "N/A";
                }
                WriteLine(output);
            }
        }
        public static Dir CD(Dir dir,string name)
        {
            if (name != "..")
            {
                Dir newdir = FindDirByName(dir, name);
                if (newdir != null)
                {
                    return newdir;
                }
                else
                {
                    WriteLine("No Such Directory");
                    return null;
                }
            }
            else if (dir.parent == null)
            {
                return dir;
            }
            else
            {
                return dir.parent;
            }
        }
    }
}
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
