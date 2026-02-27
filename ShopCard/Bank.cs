using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCard
{
    interface IBank
    {
        ICard Card { get; }
        string Name { get; }
    }
    class BankALFA : IBank
    {
        public ICard Card { get; set; } = new CardALFA();

        public string Name { get; } = "BankALFA";
    }
    class BankRetro : IBank
    {
        public ICard Card { get; set; } = new CardRetro();

        public string Name { get; } = "BankRetro";
    }
    class BankPremium : IBank
    {
        public ICard Card { get; set; } = new CardPremium();

        public string Name { get; } = "BankPremium";
    }
}
