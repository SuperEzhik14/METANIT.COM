using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METANIT
{
    class Class
    {
        public string Name { get; set; }
        public int RandomInt { get { return new Random().Next(1000000000); }}
    }
    struct StructBook
    {
        public StructBook(string name)
        {
            this.name = name;
        }
        public string name { get; private set; }
    }
}
