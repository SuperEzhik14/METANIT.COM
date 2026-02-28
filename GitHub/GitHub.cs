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
        public GitHub()
        {
            GetProgram();
        }
        public void GetProgram()
        {
            GetAccount();
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
        public void GetAccount()
        {
            int index = 0;
            if (this.Account == null)
            {
                Console.WriteLine("                                    Выбирите Способ Регистрации!");
                Console.WriteLine();
                while (true)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine();
                    if (index == 0)
                    {
                        Console.WriteLine("                             ───────────────                        ");
                    }
                    else
                    {
                        Console.WriteLine("                                                    ───────────────");
                    }
                    Console.WriteLine("                          [    Регистрация    ]   [ АвтоРегистрация ]");
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Spacebar)
                    {
                        if (index == 1)
                        {
                            index = 0;
                        }
                        else
                        {
                            index = 1;
                        }
                    }
                    else if (key == ConsoleKey.D)
                    {
                        if (index == 1)
                        {
                            RegistrGenericAVTO();
                        }
                        else
                        {
                            Registr();
                        }
                        break;
                    }

                }
            }
        }
        private void RegistrGenericAVTO()
        {
            Console.Clear();
            string name = "SuperEzhik";
            if (name.Length >= 13)
            {
                string str = "";
                for (int i = 0; i < 12; i++)
                {
                    str += name[i];
                }
                name = str;
            }
            Account = new Account(name, Generic.Password(name));
            Console.WriteLine($"Вы Успешно Зарегистрировались, Добро Пожаловать в GitHub");
            Console.WriteLine($"Ваш данные:");
            Console.WriteLine($"\tИмя:    {Account.Name}");
            Console.WriteLine($"\tПароль: {Account.Password}");
            Console.WriteLine($"\tID:     {Account.GetHashCode()}");
            Console.ReadKey();
        }
        private void Registr()
        {
            Console.Clear();
            Console.WriteLine($"Добро Пожаловать в GitHub, Пройдите Регистрацию!");
            string name;
            while (true)
            {
                Console.WriteLine("Имя Должно Иметь 4-12 символов");
                Console.Write($"\tИмя: ");
                name = Console.ReadLine();
                if (name.Length <= 12 && name.Length >= 4)
                {
                    break;
                }
                
            }
            string pass;
            while (true)
            {
                Console.WriteLine("Пароль Должен Иметь 10-20 символов");
                Console.Write($"\tПароль: ");
                pass = Console.ReadLine();
                if (pass.Length >= 10 && pass.Length <= 20)
                {
                    break;
                }
                
            }
            Account = new Account(name,pass);
            Console.Clear();
            Console.WriteLine($"Вы Успешно Зарегистрировались, Добро Пожаловать в GitHub");
            Console.WriteLine($"Ваш данные:");
            Console.WriteLine($"\tИмя:    {Account.Name}");
            Console.WriteLine($"\tПароль: {Account.Password}");
            Console.WriteLine($"\tID:     {Account.GetHashCode()}");
            Console.ReadKey();
        }
    }
}
