using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using SubOS;

namespace SubOS
{
    internal class VBIOS
    {
        public static void Main()
        {
            ReadKey();
            Write(@" ___                              _   _             "); BackgroundColor = ConsoleColor.DarkMagenta; ForegroundColor = ConsoleColor.White; Write(    @"      _  _       _     "); BackgroundColor = ConsoleColor.Black; ForegroundColor = ConsoleColor.Gray; WriteLine(@"   __      __  "); 
            Write(@"| _ \_____ __ _____  _ _  ___  __| | | |__  _  _    "); BackgroundColor = ConsoleColor.DarkMagenta; ForegroundColor = ConsoleColor.White; Write(    @"     | \| | ___ | |_   "); BackgroundColor = ConsoleColor.Black; ForegroundColor = ConsoleColor.Gray; WriteLine(@"  / /     /  \ "); 
            Write(@"|  _/ _ \ V  V / -_)| '_|/ -_)/ _` | | '_ \| || |   "); BackgroundColor = ConsoleColor.DarkMagenta; ForegroundColor = ConsoleColor.White; Write(    @"   _ | .` |/ -_)|  _|  "); BackgroundColor = ConsoleColor.Black; ForegroundColor = ConsoleColor.Gray; WriteLine(@" / _ \ _ | () |"); 
            Write(@"|_| \___/\_/\_/\___||_|  \___|\__,_| |_.__/ \_, |   "); BackgroundColor = ConsoleColor.DarkMagenta; ForegroundColor = ConsoleColor.White; Write(    @"  (_)|_|\_|\___| \__|  "); BackgroundColor = ConsoleColor.Black; ForegroundColor = ConsoleColor.Gray; WriteLine(@" \___/(_) \__/ "); 
            Write(@"                                            |__/    "); BackgroundColor = ConsoleColor.DarkMagenta; WriteLine(@"                       "); BackgroundColor = ConsoleColor.Black;
            WriteLine("AND");
            Write(@"_  _ ___  __   __   __   __   __   ___ ___ "); ForegroundColor = ConsoleColor.DarkRed; Write("████"); ForegroundColor = ConsoleColor.Green; WriteLine("██"); ForegroundColor = ConsoleColor.Gray;
            Write(@"|\/|  |  /  ` |__) /  \ /__` /  \ |__   |  "); ForegroundColor = ConsoleColor.Blue; Write("██  "); ForegroundColor = ConsoleColor.Green; WriteLine("██"); ForegroundColor = ConsoleColor.Gray;
            Write(@"|  | _|_ \__, |  \ \__/ .__/ \__/ |     |  "); ForegroundColor = ConsoleColor.Blue; Write("██"); ForegroundColor = ConsoleColor.DarkYellow; WriteLine("████"); ForegroundColor = ConsoleColor.Gray;
            Write(@" __  __ ___  __             "); ForegroundColor = ConsoleColor.DarkGreen; WriteLine(@" __  __//__//_");     ForegroundColor = ConsoleColor.Gray;
            Write(@"  \  /   |  (_  | |  /\  |  "); ForegroundColor = ConsoleColor.DarkGreen; WriteLine(@"/    _//__//__");     ForegroundColor = ConsoleColor.Gray;
            Write(@"   \/   _|_ __) |_| /--\ |_ "); ForegroundColor = ConsoleColor.DarkGreen; WriteLine(@"\__  //  //" + "\n"); ForegroundColor = ConsoleColor.Gray;
            WriteLine("Virtual System Loader online.\nSystem: Paul's SubOS made by PaulQpro\nPowered by Microsoft .NET 6.0 and Microsoft Visual C#\nMade in Visual Studio 2022\nWARNING: This Product Have no ANY Sense\nTo Start SubOS Press Any Key.");
            ReadKey();Clear();
            Program.Main();
        }
    }
}
