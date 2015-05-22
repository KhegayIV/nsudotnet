using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Khegay.Nsudotnet.TicTacToe
{
    class Program
    {
        public const ConsoleColor XColor = ConsoleColor.Cyan;
        public const ConsoleColor XColorPassive = ConsoleColor.DarkCyan;
        public const ConsoleColor OColor = ConsoleColor.Red;
        public const ConsoleColor OColorPassive = ConsoleColor.DarkRed;
        static void Main(string[] args)
        {

            Console.Write("a  W |");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("||_|||");
            Console.ReadKey();

        }
    }
}
