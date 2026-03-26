using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Back_to_the_Future
{
    class Car
    {
        public DateTime TimeNow;
        public DateTime TimeFuture;
        public List<string> HistoryFuture;
        public Ranks Rank;
        public Thread Addsecond;
        public Thread Getnewtime;
        public CarProtection protection;

        public string Name;
        public string LastName;
        public long Id;
        public int ProcentDanger;

        private int temp = 0;
        private bool worktime = false;

        public Car()
        {
            bool bl = true;
            while (bl)
            {
                Id = new Random().NextInt64(0, long.MaxValue);
                bl = false;
                foreach (var cars in Universe.AllCarsOfFuture)
                {
                    if (cars.Id == Id)
                    {
                        bl = true;
                        break;
                    }
                }           
            }
            

            
            protection = new CarProtection();
            ProcentDanger = 0;
            TimeNow = DateTime.Now;
            
            Addsecond = new Thread(AddSecond);
            Addsecond.Start();
        }
        public void Registr()
        {
            //Авторизация 
            int index = 0;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("      Добро Пожаловать в Симулятор Времени");
                Console.WriteLine();
                Console.WriteLine("                 Выбирите Должность ");
                Console.WriteLine();
                if (index == 0)
                {
                    Console.WriteLine("       ───────────────                        ");
                }
                else
                {
                    Console.WriteLine("                              ───────────────");
                }
                    Console.WriteLine("   [   Путешественник   ]   [ Временная Полиция ]");
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
                        Rank = new FuturePolice();
                    }
                    else
                    {
                        Rank = new FuturePerson();
                    }
                    break;
                }

            }
            Console.WriteLine();
            Console.Write("Введите Имя: ");
            Name = Console.ReadLine();
            Console.Write("Введите Фамилию: ");
            LastName = Console.ReadLine();
            Addsecond = new Thread(GetNewTime);
            Console.Clear();
            GetCar();
        }
        public void GetNewTime()
        {
            Console.Clear();
            Console.WriteLine("      Процесс Изменения Времени!");
            Console.WriteLine("");
            Console.WriteLine($"     Данное Время: {TimeNow}");
            Console.WriteLine($"");
            Console.WriteLine($"     Введите Все Параметры");
            Console.WriteLine($"");
            try
            {
                Console.Write($"  Год:");
                int year = int.Parse(Console.ReadLine());
                Console.Write($"  Мес:");
                int mount = int.Parse(Console.ReadLine());
                Console.Write($"  День:");
                int day = int.Parse(Console.ReadLine());


                Console.Write($"  Час:");
                int hours = int.Parse(Console.ReadLine());
                Console.Write($"  Минут:");
                int minute = int.Parse(Console.ReadLine());
                Console.Write($"  Секунд:");
                int second = int.Parse(Console.ReadLine());

                Console.WriteLine("Параметры Успешно Активироны");
                Thread.Sleep(3000);

                TimeFuture = new DateTime(year, mount, day, hours, minute, second);
                HistoryFuture.Add($"из {TimeNow.ToString("d")},в {TimeFuture}");

                Console.Clear();
                
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Ошибка! Повторите снова..");
                Console.ReadKey();
            }
        }
        public void GetCar()
        {
            while (true)
            {
                
                Print();
                Switch();
            }
        }
        public void Print()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"   Добро Пожаловать в Симулятор Времени     ID: {Id}      ");
            Console.WriteLine($"   Возможная Проверка: {ProcentDanger}%       ");
            Console.WriteLine($"   Робото Способность: {protection.Procent}%    ");
            Console.Write($"   Тех Сопровождение : ");
            switch (protection.Procent)
            {
                case < 20: Console.Write("Необходимо   "); break;
                case < 30: Console.Write("Требуется    "); break;
                case < 40: Console.Write("Следует      "); break;
                case < 50: Console.Write("Желательно   "); break;
                case < 65: Console.Write("Рекомендуется"); break;
                case < 80: Console.Write("Разрешается  "); break;
                case <= 100: Console.Write("Не требуется "); break;
            }
            Console.WriteLine();
            Console.WriteLine($"   Статус: {Rank.ToString()}");
            Console.WriteLine("");
            Console.WriteLine($"   Данное Время: {TimeNow}  ");
            Console.WriteLine($"            Рабочие Табло  ");
            Console.WriteLine($"");
            Console.WriteLine($" [   A   ]  [   S   ]  [    С    ]");
            Console.WriteLine($" [Починка]  [ Время ]  [Сообщение]");
            Console.WriteLine($"");
            Console.WriteLine($" [   V   ]  [   F   ]  [    D    ]");
            Console.WriteLine($" [История]  [Магазин]  [Поддержка]");
        }
        public void GetNowTime()
        {
            
            while (worktime)
            {
                temp++;

                if (TimeFuture >= TimeNow)
                {
                    TimeNow = TimeNow.AddMilliseconds(1);


                    if (temp <= 200)
                    {
                        TimeNow = TimeNow.AddSeconds(1);
                    }
                    else if (temp <= 400)
                    {
                        TimeNow = TimeNow.AddSeconds(3);
                    }
                    else if (temp <= 600)
                    {
                        TimeNow = TimeNow.AddSeconds(10);
                    }
                    else if (temp <= 800)
                    {
                        TimeNow = TimeNow.AddSeconds(20);
                    }
                    else if (temp <= 1000)
                    {
                        TimeNow = TimeNow.AddSeconds(40);
                    }
                    else if (temp <= 1200)
                    {
                        TimeNow = TimeNow.AddMinutes(1);
                    }
                    else if (temp <= 3000)
                    {
                        TimeNow = TimeNow.AddMinutes(3);
                    }
                    else if (temp <= 5000)
                    {
                        TimeNow = TimeNow.AddMinutes(10);
                    }
                    else if (temp <= 10000)
                    {
                        TimeNow = TimeNow.AddMinutes(30);
                    }
                    else if (temp <= 50000)
                    {
                        TimeNow = TimeNow.AddHours(1);
                    }
                    else if (temp <= 100000)
                    {
                        TimeNow = TimeNow.AddDays(1);
                    }
                    else if (temp <= 200000)
                    {
                        TimeNow = TimeNow.AddDays(5);
                    }
                    else
                    {
                        TimeNow = TimeNow.AddDays(10);
                    }



                    if (TimeNow >= TimeFuture)
                    {
                        for (int i = 0; i < 100000; i++)
                        {
                            TimeNow = TimeNow.AddMilliseconds(-1);
                        }
                        TimeNow = (DateTime)TimeFuture;

                        temp = 0;
                        worktime = false;
                    }

                }
                else if (TimeFuture <= TimeNow)
                {

                    TimeNow = TimeNow.AddMilliseconds(-1);

                    if (temp <= 200)
                    {
                        TimeNow = TimeNow.AddSeconds(-1);
                    }
                    else if (temp <= 400)
                    {
                        TimeNow = TimeNow.AddSeconds(-3);
                    }
                    else if (temp <= 600)
                    {
                        TimeNow = TimeNow.AddSeconds(-10);
                    }
                    else if (temp <= 800)
                    {
                        TimeNow = TimeNow.AddSeconds(-20);
                    }
                    else if (temp <= 1000)
                    {
                        TimeNow = TimeNow.AddSeconds(-40);
                    }
                    else if (temp <= 1200)
                    {
                        TimeNow = TimeNow.AddMinutes(-1);
                    }
                    else if (temp <= 3000)
                    {
                        TimeNow = TimeNow.AddMinutes(-3);
                    }
                    else if (temp <= 5000)
                    {
                        TimeNow = TimeNow.AddMinutes(-10);
                    }
                    else if (temp <= 10000)
                    {
                        TimeNow = TimeNow.AddMinutes(-30);
                    }
                    else if (temp <= 50000)
                    {
                        TimeNow = TimeNow.AddHours(-1);
                    }
                    else if (temp <= 100000)
                    {
                        TimeNow = TimeNow.AddDays(-1);
                    }
                    else if (temp <= 200000)
                    {
                        TimeNow = TimeNow.AddDays(-5);
                    }
                    else
                    {
                        TimeNow = TimeNow.AddDays(-10);
                    }


                    if (TimeNow <= TimeFuture)
                    {
                        for (int i = 0; i < 100000; i++)
                        {
                            TimeNow = TimeNow.AddMilliseconds(1);
                        }
                        TimeNow = (DateTime)TimeFuture;

                        temp = 0;
                        worktime = false;
                    }

                }
            }
        }
        public void Switch()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey Key = Console.ReadKey().Key;

                switch (Key)
                {
                    case ConsoleKey.S:
                        Console.Clear();
                        Console.WriteLine($"   Процесс Изменения Времени!");
                        Console.WriteLine("");
                        Console.WriteLine($"   Данное Время: {TimeNow}");
                        Console.WriteLine($"   Введите Все Параметры");
                        Console.WriteLine($"");
                        try
                        {
                            Console.Write($"  Год:");
                            int year = int.Parse(Console.ReadLine());
                            Console.Write($"  Мес:");
                            int mount = int.Parse(Console.ReadLine());
                            Console.Write($"  День:");
                            int day = int.Parse(Console.ReadLine());


                            Console.Write($"  Час:");
                            int hours = int.Parse(Console.ReadLine());
                            Console.Write($"  Минут:");
                            int minute = int.Parse(Console.ReadLine());
                            Console.Write($"  Секунд:");
                            int second = int.Parse(Console.ReadLine());

                            Console.WriteLine("Параметры Успешно Активироны");

                            Thread.Sleep(3000);

                            TimeFuture = new DateTime(year, mount, day, hours, minute, second);

                            if (Rank != new FuturePolice())
                            {
                                if ((TimeFuture.Year - TimeNow.Year) > 10)
                                {
                                    ProcentDanger++;
                                    if ((TimeFuture.Year - TimeNow.Year) > 100)
                                    {
                                        ProcentDanger += 20;
                                        if ((TimeFuture.Year - TimeNow.Year) > 500)
                                        {
                                            ProcentDanger += 100;
                                        }
                                    }
                                    

                                    if (ProcentDanger > 100)
                                    {
                                        ProcentDanger = 100;
                                    }
                                }

                                protection.GetProcent();
                            }
                            else
                            {
                                protection.GetProcent();
                            }

                            worktime = true;

                            Getnewtime = new Thread(GetNewTime);
                            Getnewtime.Start();

                            Console.Clear(); 
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка! Повторите снова..");
                            Console.ReadKey();
                        }

                        break;
                    case ConsoleKey.A: break;
                    case ConsoleKey.D:
                        Console.Clear();
                        while (true)
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("   Список Путешественников во Времени");
                            int num2 = 0;
                            List<Car> cars2 = Universe.AllCarsOfFuture.ToList();
                            foreach (var item in cars2)
                            {
                                num2++;
                                Console.WriteLine($"»»  {item.TimeNow.ToString("G")} | Status: {item.Rank.ToString()} | ID: {item.Id}                         ");
                            }

                            if (Console.KeyAvailable)
                            {
                                Console.ReadKey();
                                break;
                            }

                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.V:
                        Console.Clear();
                        Console.WriteLine("   История Перемещений во Времени");
                        foreach (var item in HistoryFuture)
                        {
                            Console.WriteLine(">>  " + item);
                            Thread.Sleep(50);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public void AddSecond()
        {
            while (true)
            {
                Thread.Sleep(1000);
                TimeNow = TimeNow.AddSeconds(1);
            }
        }
    }
}
