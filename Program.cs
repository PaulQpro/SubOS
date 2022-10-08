using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using static System.Console;
using static System.Threading.Thread;
using static SubOS.VFS;
using static SubOS.B_CMD;

namespace SubOS
{
    class Program
    {
        static Dir current = new();
        static void Ini(VFS fs)
        {
            ForegroundColor = ConsoleColor.White;
            Write("Welcome to Paul's SubOS"); Sleep(350); WriteLine(" version 0.2");
            Write("VFS (Virtual File System) version 0.1 :"); Sleep(350); ForegroundColor = ConsoleColor.DarkGreen; WriteLine(" Initialized"); ForegroundColor = ConsoleColor.White;
            Write("B_CMD (Basic Command)"); Sleep(350); Write(" version 0.2 :");  Sleep(350); ForegroundColor = ConsoleColor.DarkGreen; WriteLine(" Initialized"); ForegroundColor = ConsoleColor.White;
            Write("EE_NET (Easteregg.NET)"); Sleep(350); Write(" version 0.069 :"); Sleep(350); ForegroundColor = ConsoleColor.DarkGreen; WriteLine(" Initialized"); ForegroundColor = ConsoleColor.White;
            Write("VRFS_IO (Virtual/Real File System Input/Output) :"); Sleep(350); ForegroundColor = ConsoleColor.DarkYellow; WriteLine(" WiP"); ForegroundColor = ConsoleColor.White;
            Write("SCal (Simple Calculator) :"); Sleep(350); ForegroundColor = ConsoleColor.DarkYellow; WriteLine(" WiP"); ForegroundColor = ConsoleColor.White;
            Write("VCG (Virtual Console Games) :"); Sleep(350); ForegroundColor = ConsoleColor.Red; WriteLine(" Idea only, not Not Planned"); ForegroundColor = ConsoleColor.White;
            Write("ACal (Advanced Calculator) :"); Sleep(350); ForegroundColor = ConsoleColor.Red; WriteLine(" Planned, not WiP"); ForegroundColor = ConsoleColor.White;
            WriteLine("Press Any key to continue");
            ReadKey();
            Write("Initializating VFS...");
            fs.disks.Add(new VFS.Disk('C', "Local Disk", new Dir("Local Disk C", null, 'C', true, false)));
            Disk C = fs.disks[0];
            current = C.root;
            MD(current, "SubOS");
            current = CD(current, "SubOS");
            MD(current, "System42");
            MD(current, "Lang");
            MF(current, "SubOS", "sys", false);
            MF(current, "VFS", "sys", false);
            MF(current, "B_CMD", "lib", false);
            MF(current, "EE_NET", "net", false);
            current = CD(current, "System42");
            MF(current, "DOS", "con", true);
            MF(current, "UNIX", "con", true);
            MF(current, "Console", "lib", false);
            MF(current, "IO", "lib", false);
            current = CD(current, "..");
            current = CD(current, "Lang");
            MF(current, "EN-US", "lang", false);
            current = C.root;
            MD(current, "Apps");
            current = CD(current, "Apps");
            MD(current, "SCal");
            current = CD(current, "SCal");
            MF(current, "SCal", "app", true);
            MF(current, "Scal", "lib", false);
            current = C.root;
            Sleep(1000);
            WriteLine("Done!\nStarting C:\\SubOS\\System42\\DOS.con");
            Sleep(850);
            Clear();
        }
        
        static public void Main()
        {
            VFS fs = new();
            Ini(fs);
            ConDispType type = ConDispType.DOS;
            while (true)
            {
                int res = Console_COM(fs, type);
                if (res == 0) break;
                else if (res == 1) type = ConDispType.DOS;
                else if (res == 2) type = ConDispType.UNIX;
            }
        }
        public static int Console_COM(VFS fs, ConDispType type)
        {
            while (true)
            {
                if (type == ConDispType.UNIX) Write(current.path.Substring(0, current.path.Length-1).Replace('\\', '/') + "$ ");
                else if (type == ConDispType.DOS) Write(current.path + ">");
                string cmd = ReadLine()!.Trim().ToUpper();
                string[] args = cmd.Split(' ');
                for (int i = 0; i < args.Length; i++)
                {
                    args[i] = args[i].Trim('\"');
                }
                cmd = args[0];
                int outCode = CMD_HANDLER(current, fs, cmd, args, out current);
                if (outCode == 0xE) return 0;
                else if (outCode == 0xD) return 1;
                else if (outCode == 0xB) return 2;
            }
        }
    }
}