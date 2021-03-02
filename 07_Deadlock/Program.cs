using System;
using System.Threading;

namespace _07_Deadlock
{
    class Program
    {
        static object object1 = new object();
        static object object2 = new object();

        public static void First()
        {
            lock (object1)
            {
                Thread.Sleep(1000);
                lock (object2)
                {
                    Console.WriteLine("This will not be in output");
                }
            }

            Console.WriteLine("This will not be in output");
        }

        public static void Second()
        {
            lock (object2)
            {
                Thread.Sleep(1000);
                lock (object1)
                {
                    Console.WriteLine("This will not be in output");
                }
            }

            Console.WriteLine("This will not be in output");
        }

        static void Main()
        {
            Thread thread1 = new Thread(First);
            Thread thread2 = new Thread(Second);

            thread1.Start();
            thread2.Start();

            Console.WriteLine("Deadlock demo. Please check where threads are stuck.");
            Console.ReadLine();
        }
    }
}
