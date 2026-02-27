using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPractick
{

    public class Message
    {
        public string Name { get; set; }
        public Message(string name)
        {
            this.Name = name;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Message mes && mes.Name == Name)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "Message";
        }
    }
    public class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
        public override string ToString()
        {
            return "EmailMessage";
        }
    }
    public class SmsMessage : Message
    {
        public SmsMessage(string text) : base(text) { }
        public override string ToString()
        {
            return "SmsMessage";
        }
    }
}
