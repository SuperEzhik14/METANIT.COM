global using ClassLibrary4;
using System;
using System.Threading.Channels;
namespace ConsoleAppPractick
{
    class ModerMessenger<M, Type>
        where M : Message
        where Type : Person
    {
        protected List<Account<M>> list = new List<Account<M>>();
        protected string MessengerName;
    }
    class Messenger<M,Type> : ModerMessenger <M,Type>
        where M : Message 
        where Type : Person
    {
        
        
        public Account<M> Account = null;        
        public Messenger(string MessengerName)
        {
            this.MessengerName = MessengerName;
            
        }
        public void GetAccount(Person person)
        {
            int index = 0;
            if (this.Account == null)
            {
                Console.WriteLine("                                    Выбирите Способ Регистрации!");
                Console.WriteLine();
                while (true)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine();
                    if (index == 0)
                    {
                    Console.WriteLine("                             ───────────────                        ");
                    }
                    else
                    {
                        Console.WriteLine("                                                    ───────────────");
                    }
                    Console.WriteLine("                          [    Регистрация    ]   [ АвтоРегистрация ]");
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Spacebar)
                    {
                        if (index == 1)
                        {
                            index = 0;
                        }
                        else
                        {
                            index = 1;
                        }
                    }
                    else if (key == ConsoleKey.D)
                    {
                        if (index == 1)
                        {
                            RegistrGenericAVTO(person);
                        }
                        else
                        {
                            Registr();
                        }
                        break;
                    }

                }
            }
        }
        private void RegistrGenericAVTO(Person person)
        {
            Console.Clear();
            string str = person.Name;
            if (person.Name.Length >= 13)
            {
                str = "";
                for (int i = 0; i < 12; i++)
                {
                    str += person.Name[i];
                }
            }
            Account = new Account<M>(str,Generic.Password(person.Name));
            list.Add(Account);
            Console.WriteLine($"Вы Успешно Зарегистрировались, Добро Пожаловать в {MessengerName}");
            Console.WriteLine($"Ваш данные:");
            Console.WriteLine($"\tИмя:    {Account.Name}");
            Console.WriteLine($"\tПароль: {Account.Password}");
            Console.WriteLine($"\tID:     {Account.Id}");
        }
        private void Registr()
        {
            Console.Clear();
            Console.WriteLine($"Добро Пожаловать в {MessengerName}, Пройдите Регистрацию!");
            string name; 
            while (true)
            {
                Console.Write($"\tИмя: ");
                name = Console.ReadLine();
                if (name.Length <= 12 && name.Length >= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Имя Должно Иметь 4-12 символов");
                }
            }
            string pass;
            while (true)
            {
                Console.Write($"\tПароль: ");
                pass = Console.ReadLine();
                if (pass.Length >= 10 && pass.Length <= 20)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Пароль Должен Иметь 10-20 символов");
                }
            }
            Account = new Account<M>(name, pass);
            list.Add(Account);
            Console.Clear();
            Console.WriteLine($"Вы Успешно Зарегистрировались, Добро Пожаловать в {MessengerName}");
            Console.WriteLine($"Ваш данные:");
            Console.WriteLine($"\tИмя:    {Account.Name}");
            Console.WriteLine($"\tПароль: {Account.Password}");
            Console.WriteLine($"\tID:     {Account.Id}");
        }
        public void PrintWindowMessenger()
        {
            Console.Clear();
            Console.WriteLine($")   Профиль     )   |*{MessengerName[0]}*|  {Print.Name(MessengerName)}| Найти Друзей [G] |");
            Console.WriteLine($"(Звание:{Print.Name8(Account.Status.Name)}(   │   │   Друзья     │                  │");
            Console.WriteLine($") Настройки [F] )   |   |              |                  |");
            for (int i = 0; i < Account.MyFriends.Count; i++)
            {
                Console.WriteLine($"                (   │ {Account.MyFriends[i].Smile} │ {Print.Name(Account.MyFriends[i].Name)} │  Звание:{Print.Name8(Account.MyFriends[i].Status.Name)} │");
                Thread.Sleep(50);
                Console.WriteLine($"                )   |   |              |                  |");
                Thread.Sleep(50);
            }
            for (int i = 0; i <  8 - Account.MyFriends.Count; i++)
            {
                Console.WriteLine($"                (   │   │              │                  │");
                Thread.Sleep(50);
                Console.WriteLine($"                )   |   |              |                  |");
                Thread.Sleep(50);
            }
            if (Account.MyFriends.Count == 0)
            {
                Console.WriteLine($"                (   │   │ Нету Друзей..│                  │");
            }
        }
        public void SendMessageForPerson(Person person, M message)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (person.Name == list[i].Name)
                {
                    
                }
            }
        }
        public void SendMessage(Account<M> Account, M message)
        {

        }
    }
    internal class Program
    {
        delegate void NoParameters();
        static void Main(string[] args)
        {
            Person person = new Person("maxim");
            Person person2 = new Person("Maxim");
            Messenger<Message, Person> telegram = new Messenger<Message, Person>("telegram");
            telegram.GetAccount(person);
            Thread.Sleep(500);
            telegram.PrintWindowMessenger();
        }
    }
}


