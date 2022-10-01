using System;
using System.Collections;
using static System.Console;
using static System.Threading.Thread;
using SubOS;

namespace SubOS
{
    public class B_CMD
    {
        static public void HELP()
        {
            WriteLine("Use \"HELP <module>\" to get help of installed modules.\nList of modules:\nSUBOS, VFS, B_CMD, EE_NET");
        }
        static public void HELP(string module)
        {
            if(module == "SUBOS")
            {
                WriteLine("Paul's SubOS version 0.1\nPublisher: Experemintal Software Studio \"Pendalf\"\nDevoloper: \"YouShallNotPass\" LLC and PaulQpro");
            }
            else if (module == "VFS")
            {
                WriteLine("Virtual File System version 0.1\nPublisher: Experemintal Software Studio \"Pendalf\"\nDevoloper: \"YouShallNotPass\" LLC and PaulQpro");
                WriteLine("Commands:\nCD - Change Directory, usage \"CD <Name of Directory>\" or \"CD ..\"\nDIR - Print Current Directory on Screen, usage \"DIR\"");//\nMD - Make Directory, usage \"MD <Name>\"\nMF - Make File, usage \"MF <Name> <Type>\" or \"MD <Name>\"
            }
            else if (module == "B_CMD" || module == "CMD")
            {
                WriteLine("Basic Commands version 0.1\nPublisher: Experemintal Software Studio \"Pendalf\"\nDevoloper: \"YouShallNotPass\" LLC and PaulQpro");
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