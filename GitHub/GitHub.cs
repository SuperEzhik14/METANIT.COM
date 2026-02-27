using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub
{
    class GitHub
    {
        public Account Account { get; set; }
        public void GetProgram()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("  --Welcome-to-the-GitHub--  ");
                Console.WriteLine("Comands:");
                Console.WriteLine(" 1. Open Projects");
                Console.WriteLine(" 2. Open Account");

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1: Account.PrintProjects(); break;
                    case ConsoleKey.D2: Account.Info(); break;
                }
            }
        }
    }
}
