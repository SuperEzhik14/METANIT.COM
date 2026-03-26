using ClassLibrary4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
    class Project
    {
        private List<string> lines = new List<string>();
        private int indexline = 0;
        private int indexlinechar = 0;
        private int indexlinecharforcopy = 0;
        private string stringcopy;
        private string nameproject;
        private string action;
        public Project(string name)
        {
            nameproject = name;
            lines.Add("");
            Open();
        }
        public void Open()
        {
            Console.Clear();
            while (true)
            {
                
                Switch();
                Print();
            }
        }
        private void Switch()
        {
            if (Console.KeyAvailable)
            {
                if (action == "writeing")
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    ConsoleKey key2 = keyInfo.Key;
                    char ch = keyInfo.KeyChar; // символ, если это буква/цифра

                    // Ввод обычных символов
                    if (!char.IsControl(ch)) // фильтруем спецклавиши
                    {
                        if (lines[indexline].Length >= 1)
                        {
                            lines[indexline] = lines[indexline].Insert(indexlinechar, ch.ToString());
                            indexlinechar++;
                        }
                        else
                        {
                            lines[indexline] = ch.ToString();
                            indexlinechar = 1;
                        }
                    }
                    else if (key2 == ConsoleKey.Spacebar)
                    {
                        lines[indexline] = lines[indexline].Insert(indexlinechar, " ");
                        indexlinechar++;
                    }
                    else if (key2 == ConsoleKey.Delete)
                    {
                        if (lines[indexline].Length > 0 && indexlinechar < lines[indexline].Length)
                        {
                            // удаляем символ под курсором
                            lines[indexline] = lines[indexline].Remove(indexlinechar, 1);
                        }
                    }
                    else if (key2 == ConsoleKey.Backspace)
                    {
                        if (indexlinechar > 0)
                        {
                            indexlinechar--;
                            lines[indexline] = lines[indexline].Remove(indexlinechar, 1);
                        }
                    }
                    else if (key2 == ConsoleKey.Escape)
                    {
                        action = "none";
                    }
                    else if (key2 == ConsoleKey.RightArrow)
                    {
                        if (indexlinechar < lines[indexline].Length)
                        {
                            indexlinechar++;
                        }
                    }
                    else if (key2 == ConsoleKey.LeftArrow)
                    {
                        if (indexlinechar > 0)
                        {
                            indexlinechar--;
                        }
                    }


                    return;
                }
                
                if (action == "copying")
                {
                    ConsoleKey key2 = Console.ReadKey().Key;

                    switch (key2)
                    {
                        case ConsoleKey.LeftArrow:
                            if (indexlinechar > 0)
                            {
                                indexlinechar--;
                            }
                            
                            break;
                        case ConsoleKey.RightArrow:
                            if (indexlinechar < lines[indexline].Length)
                            {
                                indexlinechar++;
                            }
                            break;
                        case ConsoleKey.Delete:

                            if (lines[indexline].Length > 0)
                            {
                                int start = Math.Min(indexlinechar, indexlinecharforcopy);
                                int end = Math.Max(indexlinechar, indexlinecharforcopy);
                                int length = end - start + 1;

                                if (start >= 0 && start + length <= lines[indexline].Length)
                                {
                                    lines[indexline] = lines[indexline].Remove(start, length);
                                    // курсор ставим в начало удалённого участка
                                    indexlinechar = start;
                                }
                            }
                            action = "none";
                            break;
                        case ConsoleKey.Spacebar: // копирование
                            if (lines[indexline].Length > 0)
                            {
                                int start = Math.Min(indexlinechar, indexlinecharforcopy);
                                int end = Math.Max(indexlinechar, indexlinecharforcopy);
                                int length = end - start + 1;

                                if (start >= 0 && start + length <= lines[indexline].Length)
                                {
                                    stringcopy = lines[indexline].Substring(start, length);
                                }
                            }
                            break;
                        default:action = "none"; break;
                    }
                     
                    return;
                }


                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.S:
                        if (indexline < lines.Count - 1)
                        {
                            indexline++;
                            if (lines[indexline].Length > 0)
                                indexlinechar = lines[indexline].Length - 1;
                            else
                            {
                                indexlinechar = 0;
                            }
                        }
                        else
                        {
                            indexline = 0;
                            if (lines[indexline].Length > 0)
                                indexlinechar = lines[indexline].Length - 1;
                            else
                            {
                                indexlinechar = 0;
                            }
                        }
                        
                        break;
                    case ConsoleKey.F:
                        lines.Add("");
                        indexline++;
                        indexlinechar = 0;
                        Console.Clear();
                        break;
                    case ConsoleKey.D:
                        action = "writeing";
                       
                            
                        Console.Clear();
                        break;
                    case ConsoleKey.V:
                        if (!string.IsNullOrEmpty(stringcopy))
                        {
                            if (indexlinechar >= 0 && indexlinechar <= lines[indexline].Length)
                            {
                                lines[indexline] = lines[indexline].Insert(indexlinechar, stringcopy);
                                indexlinechar += stringcopy.Length; // курсор смещаем вправо
                            }
                        }
                        break;
                    case ConsoleKey.Spacebar:action = "copying"; indexlinecharforcopy = indexlinechar; break;
                    case ConsoleKey.RightArrow:  
                        if (indexlinechar < lines[indexline].Length - 1)
                        {
                            indexlinechar++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (indexlinechar > 0)
                        {
                            indexlinechar--;
                        }
                        break;


                }
            }
        }
        private void Print()
        {

            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"     Проэект: {nameproject}");
            Console.WriteLine();

            for (int i = 0; i < lines.Count; i++)
            {
                if (i == indexline)
                {
                    if (action == "copying")
                    {
                        string str = lines[i];
                        if (str.Length >= 2)
                        {
                            if (indexlinechar > indexlinecharforcopy)
                            {
                                str = str[0..indexlinecharforcopy];
                                str += Convert.ToString(Generic.Simvol());
                                str += lines[i][(indexlinecharforcopy)..indexlinechar];
                                str += Convert.ToString(Generic.Simvol());
                                str += lines[i][(indexlinechar)..lines[i].Length];
                            }
                            else
                            {
                                str = str[0..indexlinechar];
                                str += Convert.ToString(Generic.Simvol());
                                str += lines[i][(indexlinechar)..indexlinecharforcopy];
                                str += Convert.ToString(Generic.Simvol());
                                str += lines[i][(indexlinecharforcopy)..lines[i].Length];
                            }


                            Console.WriteLine($"{i + 1}: {str} :                                ");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1}: {str} :                                ");
                        }
       
                    }
                    else
                    {
                        string str = lines[i];
                        if (str.Length >= 2)
                        {

                            str = str[0..indexlinechar];
                            str += Convert.ToString(Generic.Simvol());
                            str += lines[i][(indexlinechar)..lines[i].Length];
                            Console.WriteLine($"{i + 1}: {str} :                                ");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1}: {str} :                                ");
                        }
                            
                    }

                    
                }
                else
                {
                    Console.WriteLine($"{i + 1}  {lines[i]}                                ");
                }
            }


            Console.WriteLine();
            Console.WriteLine($"           Рабочие Табло   ");
            Console.WriteLine($"   [   S   ]  [   D   ]  [  Esc  ]");
            Console.WriteLine($"   [Скролл ]  [Написат]  [ Выход ]");
            Console.WriteLine($"");
            Console.WriteLine($"[ SpaceBar ]  [   V   ]  [    F     ]");
            Console.WriteLine($"[Копировать]  [Вставит]  [новая стр ]");
           
        }
    }
}
