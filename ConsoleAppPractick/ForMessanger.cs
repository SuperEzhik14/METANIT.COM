using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPractick
{
    public class Account<M> where M : Message
    {
        public List<Account<M>> MyFriends = new List<Account<M>>();
        public List<M> MyMessages = new List<M>();
        public char Smile = '■';
        public int ReidIng = 0;

        public Status Status { get; set; }
        public int Id { get; }
        public string Password { get; private set; }
        public string Name { get; set; }
        public Account(string Name, string password)
        {
            
            Status = new Classic();
            this.Name = Name;
            Password = password;
            Id = GetHashCode();
        }
        
    }
}
