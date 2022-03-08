using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TPLClass.TestUri();
            string[] words = TPLClass.CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("Hello World");
            //List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            //employeeDetails.Add(new EmployeeDetails { id = 1, EmployeeName = "Shabana" });
            //employeeDetails.Add(new EmployeeDetails { id = 2, EmployeeName = "Shakil" });
            //employeeDetails.Add(new EmployeeDetails { id = 1, EmployeeName = "Shafi" });
            //employeeDetails.Add(new EmployeeDetails { id = 1, EmployeeName = "Rasool" });

            //EmployeePayrollOperations employeePayrolloperations = new EmployeePayrollOperations();
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //employeePayrolloperations.AddEmployeeToPayroll(employeeDetails);
            //stopwatch.Stop();
            //Console.WriteLine("Duration without thread" + stopwatch.ElapsedMilliseconds);
            //Console.WriteLine("-------");

            //Stopwatch stopwatch1 = new Stopwatch();
            //stopwatch1.Start();
            //employeePayrolloperations.AddEmployeeToPayrollWithThread(employeeDetails);
            //stopwatch1.Stop();
            //Console.WriteLine("Duration with thread\t" + stopwatch1.ElapsedMilliseconds);
            //Console.WriteLine("Employee count" + employeePayrolloperations.EmployeeCount());
            //Iterating for loop Without Task();
            //Iterating for loop With Task();
        }
        public static void IteratingForLoopWithoutTask()
        {
            Console.WriteLine("\n using Normal For \n");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("i={0},threads={1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }
        public static void IteratingForLoopWithTask()
        {
            Console.WriteLine("\n using parallel. For \n");
            Parallel.For(0, 10, i =>
              {
                  Console.WriteLine("i={0},threads={1}", i, Thread.CurrentThread.ManagedThreadId);
                  Thread.Sleep(10);
              });
        }
    }
}
