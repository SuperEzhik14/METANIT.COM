using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub
{
    class Account
    {
        private string name { get; set; }
        private string password { get; set; }
        private Queue<Project> Projects = new Queue<Project>();
        public Project? Project { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                Console.Clear();
                Console.WriteLine("Введите Пароль: ");
                string password = Console.ReadLine();
                if (password == this.password)
                {
                    Console.WriteLine("Успешно!");
                    Thread.Sleep(200);
                    Console.Clear();
                    Console.WriteLine($"Новое Имя: {value}");
                    this.name = value;
                    Thread.Sleep(200);
                }
                else
                {
                    Console.WriteLine("Ошибка!");
                    Thread.Sleep(200);
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                Console.Clear();
                Console.WriteLine("Введите Пароль: ");
                string password = Console.ReadLine();
                if (password == this.password)
                {
                    Console.WriteLine("Успешно!");
                    Thread.Sleep(200);
                    Console.Clear();
                    Console.WriteLine($"Новое Пароль: {value}");
                    this.password = value;
                    Thread.Sleep(200);
                }
                else
                {
                    Console.WriteLine("Ошибка!");
                    Thread.Sleep(200);
                }
            }
        }
        public Account(string name,string password)
        {
            this.name = name;
            this.password = password;
        }

        public void Info()
        {
            Console.Clear();
            Console.WriteLine("       --Comands--");
            Console.WriteLine(" 1. New Name");
            Console.WriteLine(" 2. New Password");
            Console.WriteLine("       --InfoAccount--");
            Console.WriteLine("");
            Console.WriteLine($"  Name: {Name}");
            Console.WriteLine($"  Password {Password}");
            Console.WriteLine($"  Projects: {Projects.Count}");
            
            ConsoleKey key = Console.ReadKey().Key;
            Console.Clear();
            switch (key)
            {
                case ConsoleKey.D1: Console.Write("Введите Новое Имя:"); Name = Console.ReadLine(); break;
                case ConsoleKey.D2: Console.Write("Введите Новый Пароль:"); Password = Console.ReadLine(); break;
            }
        }


        public void DelProject()
        {
            int Count = Projects.Count;

            for (int i = 0; i < Count; i++)
            {
                Project pro = Projects.Dequeue();
                if (pro.Name == Project.Name)
                {
                    if (Projects.Count > 0)
                    {
                        Project = Projects.Peek();
                    }
                    else
                    {
                        Project = null;
                    }
                     continue;
                }
                Projects.Enqueue(pro);
            }
        }
        public void AddProject()
        {
            Console.Clear();
            Console.Write("Введите Имя Нового Project: ");
            string nameproject = Console.ReadLine();
            Projects.Enqueue(new Project(nameproject));
            SwapProject();
        }
        public void PrintProjects()
        {
            bool oper = true;
            while (oper)
            {
                Console.Clear();
                Console.WriteLine("       --Comands--");
                Console.WriteLine(" 1. Create Project");
                Console.WriteLine(" 2. Swap Project");
                Console.WriteLine(" 3. Deleate Project");
                Console.WriteLine(" 4. Exit");
                Console.WriteLine("       --Projects--       ");
                Console.WriteLine("");

                if (Projects.Count <= 0)
                {
                    Console.WriteLine("      No Projects!");
                }
                else
                {
                    int Count = Projects.Count;
                    for (int i = 0; i < Count; i++)
                    {
                        Project pro = Projects.Dequeue();
                        Console.WriteLine($"   Project: {pro.Name}  Views: {pro.Views.Count}");
                        Console.WriteLine("");
                        Projects.Enqueue(pro);
                    }

                    Console.WriteLine($"   Develop Project: {Project.Name}");
                }
                
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1: AddProject(); break;
                    case ConsoleKey.D2: SwapProject(); break;
                    case ConsoleKey.D3: DelProject(); break;
                    case ConsoleKey.D4: oper = false; break;
                }
            }
        }
        public void SwapProject()
        {
            if (Projects.Count > 0)
            {
                Project = Projects.Peek();
                Projects.Dequeue();
                Projects.Enqueue(Project);
            }
        }
    }
}
