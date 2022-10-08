using System;
using System.Collections;
using static System.Console;
using static System.Threading.Thread;
using SubOS;
namespace SubOS
{
    public class SCal
    {
        static public void Menu()
        {
            Write("Volga Information Tehnology Production Presents:\n"); Sleep(1000); 
            WriteLine(
                "       CALCULATOR      "); Sleep(500); WriteLine(
                "╔═════════════════════╗\n" +
                "║                     ║\n" +
                "║     ['s']-Start     ║\n" +
                "║     ['r']-Rules     ║\n" +
                "║                     ║\n" +
                "╚═════════════════════╝\n" +
                ">"
            );
            ReadKey();
        }
    }
}