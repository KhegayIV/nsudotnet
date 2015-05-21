using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Khegay.Nsudotnet.NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your name?");
            Guesser guesser = new Guesser(Console.ReadLine());
            Console.WriteLine("I though of a number between 1 and 100, inclusive. Try to guess!");
            DateTime start = DateTime.Now;
            
            while (!guesser.Victory)
            {
                int guess;
                string input;
                while (!int.TryParse(input = Console.ReadLine(), out guess))
                {
                    if (input == "q")
                    {
                        Console.WriteLine("Sorry. Farewell.");
                        Console.ReadKey();
                        return;
                    }
                    Console.WriteLine("It's not a number!");
                }
                Console.WriteLine(guesser.Guess(guess));
            }
            
            Console.Write(guesser.FormatHistory());
            Console.WriteLine("Your time: {0:m\\:ss}", DateTime.Now.Subtract(start));
            Console.ReadKey();
        }
    
    }
}
