using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineCraft_Beta
{
    class Person
    {
        public IObject?[] Inventory = new IObject[8];
        public int IndexInventory = 0;

        public Person()
        {
           for (int i = 0; i < 8; i++)
            {
                Inventory[i] = new Dox();
            }
            Inventory[5] = new Axe();
        }
        public void Rigth(IObject obj)
        {
            Inventory[IndexInventory] ??= new Dox();
            Inventory[IndexInventory].Right(obj);
      
        }
        public void Left(IObject obj, ref Person person)
        {
            Inventory[IndexInventory] ??= new Dox();
            Inventory[IndexInventory].Left(obj, ref person);
        }

        public void IndexScrool()
        {
            if (IndexInventory < Inventory.Length)
            {
                IndexInventory++;
            }
            else
            {
                IndexInventory = 0;
            }
        }
    }
}
