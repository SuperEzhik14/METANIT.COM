using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    interface Bield
    {
        string Name { get; }
    }
    namespace Bields
    {
        class Programer : Bield
        {
            public string Name { get; } = "Programer";
        }
        class Artist : Bield
        {
            public string Name { get; } = "Artist";
        }
        
    }
    namespace Names
    {
        static class Magnum
        {
            public static void Info()
            {
                
            }
        }
        static class SevenEleven
        {
            public static void Info()
            {

            }
        }
    }
}
