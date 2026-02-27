using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCard
{
    interface IAccount
    {
        ICard Card { get; set; }
        int age { get; set; }
        int Bonus { get; }
        string name { get; set; }
        string password { get; set; }
    }
    class Account : IAccount
    {

        public Account(IBank bank)
        {
            Card = bank.Card;
        }
        public int Bonus { get; }
        public string name { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public ICard Card { get; set; }
    }
    class AccountPremium : IAccount
    {

        public AccountPremium(IBank bank)
        {
            Card = bank.Card;
        }
        public int Bonus { get; } = 2;
        public string name { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public ICard Card { get; set; }
    }
    class AccountVetron : IAccount
    {

        public AccountVetron(IBank bank)
        {
            Card = bank.Card;
        }
        public int Bonus { get; } = 4;
        public string name { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public ICard Card { get; set; }
    }
}
