using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeadlockTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select any scenario: 1, 2 or 3.\n(press the corresponding key)\n");
            Console.WriteLine(" 1 - NullReferenceException\n 2 - let's play a little\n 3 - Deadlock\n");
            Console.Write("\n>> ");

            do
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case '1':
                        Console.Write("\n");
                        Scenario1.Run();
                        break;

                    case '2':
                        Console.Write("\n");
                        Scenario2.Run();
                        break;

                    case '3':
                        Console.Write("\n");
                        Scenario3.Run();
                        break;

                    default:
                        Console.Write("\nIt's a wrong key. Try again!\n\n>> ");
                        continue;
                }

                break;
            } while (true);

            Thread.Sleep(500);
            Console.WriteLine("\nDone.");
            Console.ReadKey();
        }
    }
}
