using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineCraft_Beta
{
    static class Name
    {
        public static string PrintName(string name)
        {
            string str1 = "";
            str1 += name;
            for (int i = 0; i < 7 - name.Length; i++)
            {
                str1 += " ";
            } 
            return str1;
        }
    }
}
