
using ClassLibrary4;
using System.Threading;

namespace SearchColly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Redactor redactor = new Redactor();
        }

        
    }
    class Redactor
    {
        private string Name;
        private int orbs;
        private int LvL;
        public Redactor()
        {
            Thread thread2 = new Thread(AddMessage);
            thread2.Name = "Message";
            Thread thread1 = new Thread(AddOrbs);
            thread1.Name = "Orbs";
            thread1.Start();
            Name = "SuperEzhik";
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Account | {Name}      Orbs | {Text.ConvertToInt32(orbs)}");
                Console.WriteLine("    Redactor Beta 2.0");
                Console.WriteLine();
                Console.WriteLine(" [      S     ]  [      D     ]");
                Console.WriteLine(" [Send Message]  [  Add Orbs  ]");
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.D: LvL++; break;
                        case ConsoleKey.S: 
                            if (!thread2.IsAlive)
                            {
                                thread2.Start();
                            }
                            break;
                    }
                }

                if (thread2.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Console.WriteLine("Сообщение Проверяеться!  ");
                }
                else if (thread2.ThreadState == ThreadState.Stopped)
                {
                    Console.WriteLine("Сообщение Доставлено!    ");
                    
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("                         ");
                }
            }
        }
        
        private void AddOrbs()
        {
            if (Thread.CurrentThread.Name == "Orbs")
            {
                while (true)
                {
                    Thread.Sleep(1001 - (LvL * 100));
                    orbs++;
                }
            }   
        }
        private void AddMessage(object? obj)
        {
            if (Thread.CurrentThread.Name == "Message")
            {
                Thread.Sleep(10001 - (LvL * 1000));
                
                    
            }
        }
    }
}

