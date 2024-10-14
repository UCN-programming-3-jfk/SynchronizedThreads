using System;
using System.Collections.Generic;
using System.Threading;

namespace SynchronizedThreads
{
    class Program
    {
        private static object _lockObject = new object();
        private static List<int> _ints = new List<int>();
        static void Main(string[] args)
        {
            var thread1 = new Thread(() => Add10Ints());
            var thread2 = new Thread(() => Add10Ints());
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            for (int i = 0; i < _ints.Count; i++)
            {
                Console.WriteLine($"{i:00}:{_ints[i]}");
            }
        }

        public static void Add10Ints()
        {
            for (int number = 0; number < 10; number++)
            {
                AddIntLocked(number);
            }
        }


        private static void AddInt(int number)
        {
            _ints.Add(number);
        }

        private static void AddIntLocked(int number)
        {
            lock (_lockObject)
            {
                _ints.Add(number); 
            }
        }
    }
}
