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
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.Gray;
            Write("Volga Information Tehnology Production Presents:\n"); Sleep(1000); WriteLine("       THE CALCULATOR      ");
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            ReadKey();
        }
    }
}