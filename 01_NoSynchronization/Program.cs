using System;
using System.Threading;

namespace _01_NoSynchronization
{
    class Program
    {
        static int x = 0;
        static void Main(string[] args)
        {
            for (int i = 1; i < 6; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = $"Thread {i}";
                myThread.Start();
            }

            Console.ReadLine();
        }

        public static void Count()
        {
            x = 1;
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
        }
    }
}
