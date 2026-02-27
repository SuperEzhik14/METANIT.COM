using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPractick
{
    public static class Print
    {
        public static string Name(string name)
        {
            string str = name;
            for (int i = 0; i < 12 - name.Length; i++)
            {
                str += " ";
            }
            return str;
        }
        public static string Name8(string name)
        {
            string str = name;
            for (int i = 0; i < 8 - name.Length; i++)
            {
                str += " ";
            }
            return str;
        }
    }

    public class Generic
    {
        public static string Password(string name)
        {
            string str = "";
            for (int i = 0; i < 15; i++)
            {
                if (new Random().Next(2) == 0)
                {
                    str += name[new Random().Next(0, name.Length)];
                }
                else
                {
                    str += new Random().Next(10);
                }
            }
            return str;
        }
    }
}
