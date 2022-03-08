using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class TestingMultithreadingSpeed
    {
        // Testing the data parallel
        public static void TestingDataParallel()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("iteration:{0} Thread{ 1}" ,i,Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine();
            Parallel.For(0, 10, i =>
              {
                  Console.WriteLine("iteration:{0} Thread{ 1}", i, Thread.CurrentThread.ManagedThreadId);
                  Thread.Sleep(10);
              });
        }
        public static void IncrementCounter2()
        {
            int count = 0;
            for (long i = 1; i < 1000000; i++)
            {
                count++;
                //console.Write(count);
            }
            Console.WriteLine("Incrementcount2= " + count);
        }   
    }
}
