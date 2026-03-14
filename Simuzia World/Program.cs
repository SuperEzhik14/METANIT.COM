using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
namespace Simuzia_World
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool worktime = false;
            Stack<DateTime> History = new Stack<DateTime>();
            DateTime Time = DateTime.Now;
            DateTime? Time2 = null;
            int temp = 0;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("   Добро Пожаловать в Симулятор Времени");
                Console.WriteLine("");
                Console.WriteLine($"   Данное Время: {Time}");
                Console.WriteLine($"    Рабочие Табло  ");
                Console.WriteLine($"");
                Console.WriteLine($" [   A   ]  [   S   ]");
                Console.WriteLine($" [ Назад ]  [ Впред ]");
                Console.WriteLine($"");
                Console.WriteLine($" [   D   ]  [   F   ]");
                Console.WriteLine($" [История]  [История]");
                


                if (!worktime)
                {
                    Time = Time.AddSeconds(1);
                    Thread.Sleep(1000);
                    Console.WriteLine("                                   ");
                    Console.WriteLine("                                   ");
                }
                else
                {
                    temp++;
                    if (temp % 2 == 0)
                        Console.WriteLine($"  Изминения Времени+-+              ");
                    else
                        Console.WriteLine($"  Изминения Времени-+-              ");

                    
                    if (Time2 >= Time)
                    {
                        Time = Time.AddMilliseconds(1);


                        if (temp <= 200)
                        {
                            Time = Time.AddSeconds(1);
                        }
                        else if (temp <= 400)
                        {
                            Time = Time.AddSeconds(3);
                        }
                        else if (temp <= 600)
                        {
                                Time = Time.AddSeconds(10);
                        }
                        else if (temp <= 800)
                        {
                                Time = Time.AddSeconds(20);
                        }
                        else if (temp <= 1000)
                        {
                                Time = Time.AddSeconds(40);
                        }
                        else if (temp <= 1200)
                        {
                                Time = Time.AddMinutes(1);
                        }
                        else if (temp <= 3000)
                        {
                                Time = Time.AddMinutes(3);
                        }
                        else if (temp <= 5000)
                        {
                                Time = Time.AddMinutes(10);
                        }
                        else if (temp <= 10000)
                        {
                                Time = Time.AddMinutes(30);
                        }
                        else if (temp <= 50000)
                        {
                            Time = Time.AddHours(1);
                        }
                        else if (temp <= 100000)
                        {
                            Time = Time.AddDays(1);
                        }
                        else if (temp <= 200000)
                        {
                            Time = Time.AddDays(5);
                        }
                        else
                        {
                            Time = Time.AddDays(10);
                        }



                        if (Time >= Time2)
                        {
                            Console.WriteLine("Временное Стоп Времени");
                            Time = (DateTime)Time2;
                            Thread.Sleep(5000);
                            Console.Clear();
                            Console.WriteLine("     Изминения Времени Закончено!");
                            Console.WriteLine("     Было " + History.Peek());
                            Console.WriteLine("     Стало " + Time);
                            Console.WriteLine();
                            Console.WriteLine("+");
                            Console.WriteLine();
                            Console.WriteLine("     Было " + History.Peek().ToString("F"));
                            Console.WriteLine("     Стало " + Time.ToString("F"));
                            Console.ReadKey();
                            Console.Clear();
                            temp = 0;
                            worktime = false;
                        }

                    }
                    else if(Time2 <= Time)
                    {

                        Time = Time.AddMilliseconds(-1);

                        if (temp <= 200)
                        {
                            Time = Time.AddSeconds(-1);
                        }
                        else if (temp <= 400)
                        {
                            Time = Time.AddSeconds(-3);
                        }
                        else if (temp <= 600)
                        {
                            Time = Time.AddSeconds(-10);
                        }
                        else if (temp <= 800)
                        {
                            Time = Time.AddSeconds(-20);
                        }
                        else if (temp <= 1000)
                        {
                            Time = Time.AddSeconds(-40);
                        }
                        else if (temp <= 1200)
                        {
                            Time = Time.AddMinutes(-1);
                        }
                        else if (temp <= 3000)
                        {
                            Time = Time.AddMinutes(-3);
                        }
                        else if (temp <= 5000)
                        {
                            Time = Time.AddMinutes(-10);
                        }
                        else if (temp <= 10000)
                        {
                            Time = Time.AddMinutes(-30);
                        }
                        else if(temp <= 50000)
                        {
                            Time = Time.AddHours(-1);
                        }
                        else if (temp <= 100000)
                        {
                            Time = Time.AddDays(-1);
                        }
                        else if (temp <= 200000)
                        {
                            Time = Time.AddDays(-5);
                        }
                        else
                        {
                            Time = Time.AddDays(-10);
                        }


                        if (Time <= Time2)
                        {
                            Console.WriteLine("Временное Стоп Времени");
                            Time = (DateTime)Time2;
                            Thread.Sleep(5000);
                            Console.Clear();
                            Console.WriteLine("     Изминения Времени Закончено!");
                            Console.WriteLine("     Было " + History.Peek());
                            Console.WriteLine("     Стало " + Time);
                            Console.WriteLine();
                            Console.WriteLine("+");
                            Console.WriteLine();
                            Console.WriteLine("     Было " + History.Peek().ToString("F"));
                            Console.WriteLine("     Стало " + Time.ToString("F"));
                            Console.ReadKey();
                            Console.Clear();
                            temp = 0;
                            worktime = false;
                        }

                    }
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKey Key = Console.ReadKey().Key;

                    switch (Key)
                    {
                        case ConsoleKey.A:
                            Console.Clear();
                            Console.WriteLine("      Процесс Изменения Времени!");
                            Console.WriteLine("");
                            Console.WriteLine($"     Данное Время: {Time}");
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

                                Time2 = new DateTime(year, mount, day, hours, minute, second);

                                Console.Clear();
                                Console.WriteLine("      Введите Код Активации Изминения Времени!");
                                Console.Write($"     Код:");
                                if (Console.ReadLine() == "624479")
                                {
                                    Thread.Sleep(3000);
                                    Console.WriteLine("Код Успешно Активирован");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    worktime = true;
                                    History.Push(Time);
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Ошибка! Повторите снова..");
                                Console.ReadKey();
                            }

                            break;
                        case ConsoleKey.S: break;
                        case ConsoleKey.D: break;
                        case ConsoleKey.F:
                            Console.Clear();
                            Console.WriteLine("   История Изменений Времени");
                            int num = 0;
                            foreach (var item in History)
                            {
                                num++;
                                Console.WriteLine(num+" "+item);
                                Thread.Sleep(150);
                            }
                            Console.ReadKey();
                            Console.Clear();
                         break;
                    }
                }
            }
        }
        
        static void BlurMessage(ref string text)
        {
            string[] masiv = text.Split();


            for (int i = 0; i < masiv.Length; i++)
            {
                int CountLvL = 0;
                for (int j = 0; j < masiv[i].Length; j++)
                {
                    string obj = Convert.ToString(masiv[i][j]).ToLower();



                    switch (masiv[i].ToLower())
                    {
                        case "похуй": CountLvL = 4; break;
                        case "нахуй": CountLvL = 4; break;
                        case "хуй": CountLvL = 4; break;
                        case "гондон": CountLvL = 4; break;
                        case "жопа": CountLvL = 4; break;
                        case "пиздец": CountLvL = 4; break;
                        case "ебаный": CountLvL = 4; break;
                        case "ублюдок": CountLvL = 4; break;
                    }


                    switch (obj)
                    {
                        case "п":CountLvL++;break;
                        case "х": CountLvL++; break;
                        case "у": CountLvL++; break;
                        case "ж": CountLvL++; break;
                        case "й": CountLvL++; break;
                        case "н": CountLvL++; break;
                        case "о": CountLvL++; break;
                        case "с": CountLvL++; break;
                    }

                    if (CountLvL >= 4)
                    {
                        masiv[i] = "_*******_";
                        break;
                    }
                }
            }

            text = null;

            for (int i = 0; i < masiv.Length; i++)
            {
                text += masiv[i] + " ";
            }
        }
    }

    static class RefList
    {
        public static void Search(this List<string> List, string obj)
        {
            Console.WriteLine($"     -Search: {obj}-");

            for (int i = 0;i < List.Count;i++)
            {
                if (List[i].Contains(obj))
                {
                    Console.WriteLine(List[i]);
                }
            }
        }
        public static void SearchAll(this List<string> List, string obj)
        {
            Console.WriteLine($"     -Search: {obj}-");

            for (int i = 0; i < List.Count; i++)
            {   if (List[i].ToUpper().Contains(obj.ToUpper()))
                {
                    Console.WriteLine(List[i]);
                }
            }
        }
    }
}
