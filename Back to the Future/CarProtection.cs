using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_to_the_Future
{
    class CarProtection
    {
        public int Procent = 100;
        public int LvL = 1;

        public void GetProcent()
        {
            if (new Random().Next(0, (111 - (LvL * 10))) == 0)
            {
                return;
            }

            Procent--;
        }
    }
}
