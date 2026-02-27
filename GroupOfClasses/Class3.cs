using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupWords
{
    public static class Words
    {
        public delegate void speak();
        public static IEnumerable<speak> RandomWords()
        {
            speak[] masiv = { Speak, Good, Hello, Can, Omg };

            for (int i = 0; i < new Random().Next(2,masiv.Length); i++)
            {
                yield return masiv[new Random().Next(masiv.Length)];
            }
        }



        public static void Speak()
        {
            Console.WriteLine("How do you live?");
        }
        public static void Good()
        {
            Console.WriteLine("Good! I am living in the house!");
        }
        public static void Hello()
        {
            Console.WriteLine("Hello the best Friends!");
        }
        public static void Can()
        {
            Console.WriteLine("Hello! Can you help me");
        }
        public static void Omg()
        {
            Console.WriteLine("Your Cars are faster then my car but i am the strongest in this world");
        }
    }
}
