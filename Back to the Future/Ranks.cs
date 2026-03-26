using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_to_the_Future
{
    interface Ranks
    {

    }
    class FuturePolice : Ranks
    {
        public override string ToString()
        {
            return "Police";
        }
    }
    class FuturePerson : Ranks
    {
        public override string ToString()
        {
            return "Person";
        }
    }
}
