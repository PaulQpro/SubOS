using System;
using System.Collections;
using static System.Console;
using static System.Threading.Thread;
using SubOS;

namespace SubOS
{
    public class B_CMD
    {
        public void HELP()
        {
            WriteLine("Use \"HELP <module>\" to get help of installed modules.\nList of modules:\nSUBOS, VFS, B_CMD, EE_NET");
        }
        public void HELP(string module)
        {
            if(module == "SUBOS")
            {
                WriteLine("Paul's SubOS version 0.1\nPublisher: Experemintal Software Studio \"Pendalf\"\nDevoloper: \"YouShallNotPass\" LLC and PaulQpro");
            }
            else if (module == "VFS")
            {
                WriteLine("Virtual File System version 0.1\nPublisher: Experemintal Software Studio \"Pendalf\"\nDevoloper: \"YouShallNotPass\" LLC and PaulQpro");
                WriteLine("Commands:\nCD - Change Directory, using \"CD <Dir>\"\nMD - Make Directory, using \"MD <Name>\"\nMF - Make File, using \"MF <Name> <Type>\" or \"MD <Name>\"");
            }
        }
    }
}