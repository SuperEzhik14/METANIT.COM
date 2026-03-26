namespace Practica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            object locker = new object();
            
            void Add()
            {
                
            }

            Thread thread1 = new Thread(Add);
            Thread thread2 = new Thread(Add);

            thread1.Name = "th1";
            thread2.Name = "th2";

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Главный поток завершён");
        }
        static void Work()
        {
            Console.WriteLine("Работаю");

            Thread.Sleep(3000);

            Console.WriteLine("Работа Закончилась");
        }
    }
}
