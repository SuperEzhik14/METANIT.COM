using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineCraft_Beta
{
    
    class Log : IObject
    {
        public string Name => "Дерево";

        public int Id => 1;

        public void Left(IObject obj, ref Person person)
        {
            person.Inventory[person.IndexInventory] = obj;
            Console.WriteLine($"Вы Добыли за 30 сек{obj.Name}");
        }

        public void Right(IObject obj)
        {
            Console.WriteLine($"Вы Поставили {obj.Name}");
        }
    }
    class Dox : IObject
    {
        public string Name => "";

        public int Id => -1;

        public void Left(IObject obj, ref Person person)
        {
            person.Inventory[person.IndexInventory] = obj;
            Console.WriteLine($"Вы Добыли {obj.Name}     ");
        }

        public void Right(IObject obj)
        {
            Console.WriteLine($"Вы Поставили {obj.Name}  ");
        }
    }
    class Axe : IObject
    {
        public string Name => "Топорик";

        public int Id => -1;

        public void Left(IObject obj, ref Person person)
        {
            person.Inventory[person.IndexInventory] = obj;
            Console.WriteLine($"Вы Добыли за 10 сек{obj.Name}     ");
        }

        public void Right(IObject obj)
        {
            Console.WriteLine($"Вы Поставили {obj.Name}  ");
        }
    }
}
