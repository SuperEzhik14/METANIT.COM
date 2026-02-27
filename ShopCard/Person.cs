using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopCard
{
    class Bank<T> where T : IBank
    {
        private static List<IAccount> List = new List<IAccount>();
        private IAccount MyAccount;
        private T bank { get; set; }
        public Bank()
        {
            MyAccount = new Account(new BankPremium());
            Registr();
            List.Add(MyAccount);
        }
        private void Registr()
        {
            Console.Clear();    
            Console.Write("Введите Имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите Возраст: ");
            int age = 0;
            try
            {
                age = int.Parse(Console.ReadLine());
            }
            catch
            {
                age = 0;
            }
            Console.Write("Создайте Пароль: ");
            string password = Console.ReadLine();
            MyAccount.name = name;
            MyAccount.age = age;
            MyAccount.password = password;
        } 
        public void InfoAccount()
        {
            Console.WriteLine(MyAccount.ToString());
            Console.WriteLine("Имя: " + MyAccount.name);
            Console.WriteLine("Возраст: " + MyAccount.age);
            Console.WriteLine("Пароль: " + MyAccount.password);
            Console.WriteLine("Карта: " + MyAccount.Card.ToString());
            Console.WriteLine("Бонус: X" + MyAccount.Bonus);
        }
        public void Pay(int num)
        {
            if (MyAccount.Card.Balance >= num)
            {
                MyAccount.Card.Balance -= num;
                Console.WriteLine("Оплата Успешно Завершена");
                Console.WriteLine("Текущий Баланс: " + MyAccount.Card.Balance);
            }
            else
            {
                Console.WriteLine("Недостаточно Средств");
            }
        }
        public void ImpruveAccount()
        {
            if (MyAccount is AccountVetron)
            {
                Console.WriteLine("Упс ваш Аккаунт дошол на MAX Уровня");
                Console.WriteLine("Аккаунт некуда прокачивать!!");
            }
            else
            {
                Console.WriteLine("Стоимость Прокачика Аккаунт: 5000");
                Console.WriteLine("[Пробел] Оплатить");
                if (Console.ReadLine() == " ")
                {
                    if (MyAccount.Card.Balance >= 5000)
                    {
                        MyAccount.Card.Balance -= 5000;
                        Console.WriteLine("Оплата Успешно Завершена");
                        Console.WriteLine("Текущий Баланс: " + MyAccount.Card.Balance);
                        string name = MyAccount.name;
                        int age = MyAccount.age;
                        string password = MyAccount.password;
                        if (MyAccount is Account)
                            MyAccount = new AccountPremium(bank);
                        else
                            MyAccount = new AccountVetron(bank);
                        MyAccount.name = name;
                        MyAccount.age = age;
                        MyAccount.password = password;
                        Console.WriteLine("Аккаунт Прокачен на " + MyAccount.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно Средств");
                    }
                }
            }
                
        }
        public void GetMoney(int num)
        {
            if (MyAccount.Card.Balance < (MyAccount.Card.BalanceMAX * MyAccount.Bonus) - (MyAccount.Card.Balance - num))
            {
                MyAccount.Card.Balance += num;
                Console.WriteLine("Оплата Успешно Завершена");
                Console.WriteLine("Текущий Баланс: " + MyAccount.Card.Balance);
            }
            else
            {
                Console.WriteLine("Вы дошли до лимита!");
                Console.WriteLine("Текущий Баланс: " + MyAccount.Card.Balance);
            }
        }
    }
    class Person
    {
        public string name { get; }
        public Person(string name)
        {
            this.name = name;
        }
    }
}
