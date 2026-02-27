using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GroupOfDelegate
{
    public delegate void Group();
    public class Class4
    {
        public event Group gp; 

        public Class4(params Group[] masiv)
        {
            for (int i = 0; i < masiv.Length; i++)
            {
                gp += masiv[i];
            }
        }
        public void Print()
        {
            gp();
        }
    }
}
