using System;
using System.Threading;

namespace _06_SynchronizationWithSemaphoreAndInterlocked
{
    class Program
    {
        static int count = 0;
        static Semaphore sem = new Semaphore(5, 5);
        static void Main(string[] args)
        {
            for (int i = 1; i < 10; i++)
            {
                Thread myThread = new Thread(Work);
                myThread.Name = $"Worker {i}";
                myThread.Start();
            }

            Console.ReadLine();
        }

        private static void Work()
        {
            sem.WaitOne();

            Interlocked.Increment(ref count);

            Console.WriteLine($"{Thread.CurrentThread.Name} starting... Now working {count}");

            Thread.Sleep(new Random().Next(500, 1000));

            Console.WriteLine($"{Thread.CurrentThread.Name} finishing.. Now working {count}");

            Interlocked.Decrement(ref count);

            sem.Release();
        }
    }
}