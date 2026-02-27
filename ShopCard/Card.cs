using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCard
{
    interface ICard
    {
        string Name { get; }
        int Balance { get; set; }
        int BalanceMAX { get;}
    }
    class CardALFA : ICard
    {
        public string Name { get; } = "ALFABank";
        public int Balance { get; set; } = 0;
        public int BalanceMAX { get; } = 10000;
    }
    class CardRetro : ICard
    {
        public string Name { get; } = "RetroBank";
        public int Balance { get; set; } = 0;
        public int BalanceMAX { get; } = 25000;
    }
    class CardPremium : ICard
    {
        public string Name { get; } = "PremiumBank";
        public int Balance { get; set; } = 0;
        public int BalanceMAX { get; } = 50000;
    }
}
