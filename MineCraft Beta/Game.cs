using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MineCraft_Beta
{
    internal class Game
    {
        private Person person = new Person();
        public Game()
        {
            while (true)
            {

                if (Console.KeyAvailable == true)
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.S:
                            person.Left(new Log(), ref person); break;
                        case ConsoleKey.D:
                            person.Rigth(new Log()); break;
                        case ConsoleKey.Spacebar:
                            person.IndexScrool();break;
                    }
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("");
                    
                    for (int i = 0; i < 4; i++)
                    {
                        Console.Write("            ");
                        for (int f = 0; f < 8; f++)
                        {
                            switch (i)
                            {
                                case 0:
                                    if (f == person.IndexInventory)
                                        Console.Write("[═══════] ");
                                    else
                                        Console.Write("[       ] ");
                                    break;
                                case 1:
                                    Console.Write("|       | ");
                                    break;
                                case 2:
                                    Console.Write($"|{Name.PrintName(person.Inventory[f].Name)}| ");
                                    break;
                                case 3:
                                    if (f == person.IndexInventory)
                                        Console.Write("[═══════] ");
                                    else
                                        Console.Write("[       ] ");
                                    break;

                            }
                        }
                        Console.WriteLine();
                    }
                    
                }
            }
        }
    }
}
