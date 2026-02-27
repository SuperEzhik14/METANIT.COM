
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
namespace Simuzia_World
{
    
    internal class Program
    {
        static void Main(string[] args)
        {

            LinkedList<string> linked = new LinkedList<string>(new string[] { "Maks", "Robot", "Aldeno" });


            linked.AddFirst("sasd");



            Console.WriteLine(linked.Last.Value);

        }     
    } 

}
