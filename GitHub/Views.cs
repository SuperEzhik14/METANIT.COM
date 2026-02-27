using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub
{
    class Views
    {
        public List<string> Names = new List<string>();
        public int Count = 0;
        public Views()
        {

        }
        public void Add(Account account)
        {
            Names.Add(account.Name);
            Count++;
        }
    }
}
