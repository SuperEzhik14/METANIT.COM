using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineCraft_Beta
{
    interface IObject
    {
        string Name { get; }
        int Id { get; }
        void Left(IObject obj, ref Person person);
        void Right(IObject obj);
    }
}
