using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simuzia_World
{
    class Person<T> 
    {

        public event Action<T>? action;
        public void Print(T obj)
        {
            action.Invoke(obj);
        }
    }
}
