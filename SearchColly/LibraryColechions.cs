using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchColly
{
    static class AllLibraryes
    {
        private static List<Lazy<ICollection>> Libraryes = new List<Lazy<ICollection>>();
        static AllLibraryes()
        {
            Libraryes.Add(new Lazy<ICollection>(() => new LibraryBooksPrograming()));
            Libraryes.Add(new Lazy<ICollection>(() => new LibraryBooksHistory()));
            Libraryes.Add(new Lazy<ICollection>(() => new LibraryBooksMoney()));
        }
        public static void PrintAllLibraryes()
        {
            Console.Clear();
            Console.WriteLine("     Все Библиотеки");
            Console.WriteLine();
            int num = 0;
            foreach (var item in Libraryes)
            {
                num++;
                if (num == 1)
                {
                    Console.WriteLine($"{num}-Library[ {item.Value.namecollection} ]-");

                }
                else
                {
                    Console.WriteLine($"{num} Library[ {item.Value.namecollection} ]");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
        public static void AddLibrary() 
        {
            MyLibrary library = new MyLibrary(out bool temp);
            if (temp)
            {
                Libraryes.Add(new Lazy<ICollection>(() => library));
            }
            else
            {
                Console.WriteLine("Не Удалось Создать");
                Thread.Sleep(1000);
            }
            Console.Clear();
        }
        public static void DownoloadLibrary(ref Lazy<ICollection> myLibrary)
        {
            Console.Clear();
            
            Queue<Lazy<ICollection>> queue = new Queue<Lazy<ICollection>>(Libraryes.ToArray());

            bool temp = true;
            while (temp)
            {
                Console.WriteLine("         Выбирите Библиотеку");
                Console.WriteLine("[Пробел Swap] [S Установить]  [D Выйти]");
                Console.WriteLine();
                int num = 0;
                foreach (var item in queue)
                {
                    num++;
                    if (num == 1)
                    {
                        Console.WriteLine($"{num}-Library[ {item.Value.namecollection} ]-");

                    }
                    else
                    {
                        Console.WriteLine($"{num} Library[ {item.Value.namecollection} ]");
                    }
                }

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.Spacebar:
                        queue.Enqueue(queue.Dequeue());

                        break;
                    case ConsoleKey.S:
                        myLibrary = queue.Peek();
                        Console.WriteLine("Библиотека Успешно Установлена");
                        Thread.Sleep(1000);
                        break;
                    case ConsoleKey.D:
                        temp = false;

                        break;
                }
                Console.Clear();
            }
            Console.Clear();

        }
    }
    
    interface ICollection
    {
        public List<string> values {  get; }
        public Queue<string> queue { get; }
        public string namecollection { get; }
        public void GetSearchBooks(ref string mybook)
        {
            Console.Clear();
            Console.WriteLine($"      Раздел: {namecollection}");
            Console.WriteLine($"Введите название или часть название  Книги!");
            Console.WriteLine($"Наши алгоритмы постараются найти эту Книгу!");
            Console.Write($"Название: ");
            string name = Console.ReadLine();
            int num = 0;
            foreach (var item in values )
            {
                if (item.Contains(name))
                {
                    num++;
                    Console.WriteLine($"{num} Book[ {item} ]");
                }
            }
            Console.Write("Введите название Книги: ");
            name = Console.ReadLine();
            if (values.Contains(name))
            {
                mybook = name;
                Console.WriteLine("Книга успешно скачена!");
            }
            else
            {
                Console.WriteLine("Неверное название Книги!");
            }
            Thread.Sleep(1000);
            Console.Clear();
        }
        public void GetAllBooks(ref string mybook)
        {
            Console.Clear();
            bool temp = true;
            
            while (temp)
            {
                int num = 0;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"      Раздел: {namecollection}");
                Console.WriteLine("[Пробел Swap] [S Скачять]  [D Выйти]");
                foreach (string item in queue)
                {
                    num++;
                    if (num == 1)
                    {
                        Console.WriteLine($"{num}-Book[ {item} ]-");

                    }
                    else
                    {
                        Console.WriteLine($"{num} Book[ {item} ]");
                    }
                }
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.Spacebar:
                        queue.Enqueue(queue.Dequeue());

                        break;
                    case ConsoleKey.S:
                        if (queue.Peek() is string str)
                        {
                            mybook = str;
                            Console.WriteLine("Книга успешно скачена!");
                            Thread.Sleep(1000);
                        }

                        break;
                    case ConsoleKey.D:
                        temp = false;

                        break;
                }
            }
            Console.Clear();
        }
    }

    class LibraryBooksPrograming : ICollection
    {
        public List<string> values { get; }
        public Queue<string> queue { get; }

        public string namecollection { get; }
        public LibraryBooksPrograming()
        {
            values = new List<string>() { "C# 3.0", "C# 8.0", "C# 9.0" , "Windows 10", "Python 2.3", "Python 9" };
            queue = new Queue<string>(values.ToArray());
            namecollection = GetType().Name;
        }
    }

    class LibraryBooksHistory : ICollection
    {
        public List<string> values { get; }
        public Queue<string> queue { get; }

        public string namecollection { get; }
        public LibraryBooksHistory()
        {
            values = new List<string>() { "Иван Щельцов", "Русская Молитва", "КазаКотак", "АлтанКоже", "Бастырхан 1780", "Ребльсы" };
            queue = new Queue<string>(values.ToArray());
            namecollection = GetType().Name;
        }
    }

    class LibraryBooksMoney : ICollection
    {
        public List<string> values { get; }
        public Queue<string> queue { get; }

        public string namecollection { get; }
        public LibraryBooksMoney()
        {
            values = new List<string>() { "Как быть №1 а не №2", "Лучше потерять девушку чем 1 милион $", "Быть Подростком лучше, чем быть Богатым милиардером!", "НЕ ДУМАЙ ОБ (БАБКАХ) ДУМАЙ ОБ (ДЕНЬГАХ)", "Работай сейчас чтобы не работать потом!", "Деньги Деньги ище раз Деньги (как поменять свой разум на 90%)" };
            queue = new Queue<string>(values.ToArray());
            namecollection = GetType().Name;
        }
    }
    class MyLibrary : ICollection
    {
        public List<string> values { get; }
        public Queue<string> queue { get; }
        public string namecollection { get; }

        public MyLibrary(out bool item)
        {
            values = new List<string>();
            Console.Clear();
            Console.WriteLine("        Создание Библиотеки");
            Console.WriteLine();
            Console.Write("Введите раздел: ");
            namecollection = Console.ReadLine();
            Console.WriteLine("Сколько Книг хотите cоздать: ");
            try
            {
                int CountBooks = int.Parse(Console.ReadLine());
                for (int i = 1; i < (CountBooks + 1); i++)
                {
                    Console.Write($"{i} Book: ");
                    string str = Console.ReadLine();
                    values.Add(str);
                }
                Console.WriteLine("Библиотека Успешно Создана!");
                Console.WriteLine("Раздел: " + namecollection);
                Console.WriteLine("Количество Книг: " + CountBooks);
                item = true;
                queue = new Queue<string>(values.ToArray());
            }
            catch
            {
                Console.WriteLine("Запрещеный Символ!");
                Thread.Sleep(1000);
                item = false;
            }
            Console.Clear();
        }
    }
}
