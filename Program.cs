using System;
using static System.Console;
using static System.Threading.Thread;
using static SubOS.VFS;
using static SubOS.B_CMD;

namespace SubOS
{
    class Program
    {
        static Dir current = new();
        static void Ini()
        {
            WriteLine("Welcome to Paul's SubOS version 0.1");
            Write("VFS (Virtual File System) version 0.1 :"); Sleep(350); ForegroundColor = ConsoleColor.DarkGreen; WriteLine(" Initialized"); ForegroundColor = ConsoleColor.White;
            Write("B_CMD (Basic Command) version 0.1 :");  Sleep(350); ForegroundColor = ConsoleColor.DarkGreen; WriteLine(" Initialized"); ForegroundColor = ConsoleColor.White;
            Write("EE_NET (Easteregg.NET) version 0.069 :"); Sleep(350); ForegroundColor = ConsoleColor.DarkGreen; WriteLine(" Initialized"); ForegroundColor = ConsoleColor.White;
            Write("VRFS_IO (Virtual/Real File System Input/Output) :"); Sleep(350); ForegroundColor = ConsoleColor.DarkYellow; WriteLine(" Not Available"); ForegroundColor = ConsoleColor.White;
            Write("SCal (Simple Calculator) :"); Sleep(350); ForegroundColor = ConsoleColor.DarkYellow; WriteLine(" Not Available"); ForegroundColor = ConsoleColor.White;
            Write("VCG (Virtual Console Games) :"); Sleep(350); ForegroundColor = ConsoleColor.DarkRed; WriteLine(" Not Planned"); ForegroundColor = ConsoleColor.White;
            Write("ACal (Advanced Calculator) :"); Sleep(350); ForegroundColor = ConsoleColor.DarkRed; WriteLine(" Not Planned"); ForegroundColor = ConsoleColor.White;
            WriteLine("Press Any key to continue");
            ReadKey();
            VFS fs = new();
            fs.disks.Add(new VFS.Disk('C', "Local Disk", new Dir("Local Disk C", null, 'C', true, false)));
            Disk C = fs.disks[0];
            current = C.root;
            MD(current, "SubOS");
            current = FindDirByFullName(C.root, "SubOS");
            MF(current, "SubOS", "sys");
            MF(current, "VFS", "sys");
            MF(current, "B_CMD", "com");
            MF(current, "EE_NET", "net");
            current = C.root;
            Clear();
        }
        static void Console_COM()
        {
            B_CMD com = new();
            while (true)
            {
                Write(current.path+"\n>");
                string cmd = ReadLine()!.Trim().ToUpper();
                if (cmd.IndexOf(' ') != -1)
                {
                    string[] args = cmd.Split(' ');
                    for (int i = 0; i < args.Length; i++)
                    {
                        args[i] = args[i].Trim('\"');
                    }
                    cmd = args[0];
                    if (cmd == "HELP")
                    {
                        com.HELP(args[1]);
                    }
                    else if (cmd == "EXIT")
                    {
                        break;
                    }
                }
                else
                {
                    if(cmd == "HELP")
                    {
                        com.HELP();
                    }
                    else if(cmd == "EXIT")
                    {
                        break;
                    }
                }
            }
        }
        static public void Main()
        {
            Ini();
            Console_COM();
        }
    }
}