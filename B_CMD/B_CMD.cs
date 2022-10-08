using System;
using System.Collections;
using static System.Console;
using static System.Threading.Thread;
using SubOS;
using static SubOS.VFS;

namespace SubOS
{
    public class B_CMD
    {
        public enum ConDispType
        {
            DOS,
            UNIX
        }
        public static int CMD_HANDLER(Dir current, VFS fs, string cmd, string[] args, out Dir outCurrent)
        {
            if (cmd == "HELP")
            {
                if (args.Length > 1)
                {
                    HELP(args[1]);
                }
                else
                {
                    HELP();
                }
            }
            else if (cmd == "CD")
            {
                if (args.Length > 1)
                {
                    Dir nextCurrent = CD(current, args[1]);
                    if (nextCurrent != null)
                    {
                        current = nextCurrent;
                    }
                }
                else
                {
                    WriteLine("CD using : CD <Name of Directory> or CD ..");
                }
            }
            else if (cmd == "CD..")
            {
                Dir nextCurrent = CD(current, "..");
                if (nextCurrent != null)
                {
                    current = nextCurrent;
                }
            }
            else if (cmd == "DIR")
            {
                DIR(current, DirDisplayType.DOS);
            }
            else if (cmd == "LIST")
            {
                DIR(current, DirDisplayType.LIST);
            }
            else if (cmd == "CLR")
            {
                CLR();
            }
            else if (cmd == "EXIT")
            {
                outCurrent = current;
                return 0xE;
            }
            else
            {
                string name = cmd.Split('.')[0];
                _File file = FindFileByName(current, name);
                if (file != null && file.exe)
                {
                    switch (file.name)
                    {
                        case "DOS":
                            WriteLine("Starting C:\\SubOS\\System42\\DOS.con");
                            Sleep(850);
                            CLR();
                            outCurrent = fs.disks[0].root;
                            return 0xD;
                        case "UNIX":
                            WriteLine("Starting C:\\SubOS\\System42\\UNIX.con");
                            Sleep(850);
                            CLR();
                            outCurrent = fs.disks[0].root;
                            return 0xB;
                        case "SCal":
                            SCal.Menu();
                            break;
                        default: WriteLine("Wrong Executable"); break;
                    }
                }
                else if (file != null && (file.type == "con" || file.type == "app") && !file.exe) WriteLine("Wrong or Broken Executable");
                else WriteLine("No Such Command or Executable File (.app, .con)");
            }
            outCurrent = current;
            return 0xA;
        }
        static public void HELP()
        {
            WriteLine("Use \"HELP <module>\" to get help of installed modules.\nList of modules:\nSUBOS, VFS, B_CMD, EE_NET, SCAL");
        }
        static public void HELP(string module)
        {
            if(module == "SUBOS")
            {
                WriteLine("Paul's SubOS version 0.2\nPublisher: Experemintal Software Studio \"Pendalf\"\nDevoloper: \"YouShallNotPass\" LLC and PaulQpro");
            }
            else if (module == "VFS")
            {
                WriteLine("Virtual File System version 0.1\nPublisher: Experemintal Software Studio \"Pendalf\"\nDevoloper: \"YouShallNotPass\" LLC and PaulQpro");
                WriteLine("Commands:\nCD - Change Directory, usage \"CD <Name of Directory>\" or \"CD ..\"\nDIR - Print Current Directory on Screen, usage \"DIR\"");//\nMD - Make Directory, usage \"MD <Name>\"\nMF - Make File, usage \"MF <Name> <Type>\" or \"MD <Name>\"
            }
            else if (module == "B_CMD" || module == "CMD")
            {
                WriteLine("Basic Commands version 0.2\nPublisher: Experemintal Software Studio \"Pendalf\"\nDevoloper: \"YouShallNotPass\" LLC and PaulQpro");
                WriteLine("Commands:\nHELP - Get Help, usage \"HELP\" or \"HELP <module>\"\nCLR - Clear Screen, usage \"CLR\"\nEXIT - Close Program, usage \"EXIT\"");
            }
            else if (module == "EE_NET")
            {
                WriteLine("Easteregg.NET version 0.069\nDevoloper & Publisher: PaulQpro");
            }
        }
        static public void CLR()
        {
            Clear();
        }
    }
}