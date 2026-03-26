using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchColly
{
    class Library
    {
        private Lazy<ICollection> collection = new Lazy<ICollection>();
        private string mybook;
        public Library()
        {
            while (true)
            {
                WritePlace();
                SwitchPlace();
            }
        }
        private void WritePlace()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("   Добро Пожаловать в Библиотеку");
            Console.WriteLine("");
            Console.WriteLine($"Now-Book[{mybook ?? " Null "}]-                                ");
            Console.WriteLine();
            Console.WriteLine($"              Рабочие Табло  ");
            Console.WriteLine($"");
            Console.WriteLine($" [     S     ]  [     D     ]  [     F     ]");
            Console.WriteLine($" [Найти Книгу]  [ Все Книги ]  [Созд Библит]");
            Console.WriteLine($"");
            Console.WriteLine($" [         W        ]   [        E         ]");
            Console.WriteLine($" [  Все Библиотеки  ]   [Скачять Библиотеку]");
        }
        private void SwitchPlace()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.S:if (collection.IsValueCreated)
                        {
                            collection.Value.GetSearchBooks(ref mybook);
                            Console.WriteLine("                          ");
                        }
                        else
                        {
                            Console.WriteLine("Скачайте Библиотеку!");
                        }
                    Thread.Sleep(1000);
  
                        break;
                    case ConsoleKey.D:
                        if (collection.IsValueCreated)
                        {
                            collection.Value.GetAllBooks(ref mybook);
                            Console.WriteLine("                          ");
                        }
                        else
                        {
                            Console.WriteLine("Скачайте Библиотеку!");
                        }
                        Thread.Sleep(1000);
        
                        break;
                    case ConsoleKey.F:
                        AllLibraryes.AddLibrary();

                        break;
                    case ConsoleKey.W:
                        AllLibraryes.PrintAllLibraryes();
  
                        break;
                    case ConsoleKey.E:
                        AllLibraryes.DownoloadLibrary(ref collection);
                        break;
                }

                Console.Clear();
            }
        }
    }
}
