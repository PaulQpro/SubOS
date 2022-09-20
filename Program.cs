using System;
using static System.Console;
using static System.Threading.Thread;
using static SubOS.VFS;
using static SubOS.B_CMD;

namespace SubOS
{
    class Program
    {
        static public void Main()
        {
            WriteLine("Welcome to Paul's SubOS version 0.1");
            ForegroundColor = ConsoleColor.DarkGreen;
            Write("VFS (Virtual File System) version 0.1 :"); Sleep(1000); WriteLine(" Initialized");
            Write("B_CMD (Basic Command) version 0.1 :");  Sleep(1000); WriteLine(" Initialized");
            Write("EE_NET (Easteregg.NET) version 0.069 :"); Sleep(1000); WriteLine(" Initialized");
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("VRFS_IO (Virtual/Real File System Input/Output) : Not Available");
            WriteLine("SCal (Simple Calculator) : Not Available");
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("VCG (Virtual Console Games) : Not Planned");
            WriteLine("ACal (Advanced Calculator) : Not Planned");
            ForegroundColor = ConsoleColor.White;
            WriteLine("Press Any key to continue");
            ReadKey();
            VFS fs = new();
            fs.disks.Add(new VFS.Disk('C', "Local Disk", new Dir("Local Disk C", true, false)));
            Disk C = fs.disks[0];
            Dir current = C.root;
            MD(current, "SubOS");
            current = FindDirByFullName(C.root, "SubOS");
            MF(current, "SubOS", "sys");
            MF(current, "VFS", "sys");
            MF(current, "B_CMD", "com");
            MF(current, "EE_NET", "net");
            current = C.root;
            ReadKey();
        }
        
    }
}