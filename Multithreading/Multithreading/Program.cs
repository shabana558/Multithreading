using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            employeeDetails.Add(new EmployeeDetails { id = 1, EmployeeName = "Shabana" });
            employeeDetails.Add(new EmployeeDetails { id = 2, EmployeeName = "Shakil" });
            employeeDetails.Add(new EmployeeDetails { id = 1, EmployeeName = "Shafi" });
            employeeDetails.Add(new EmployeeDetails { id = 1, EmployeeName = "Rasool" });

            EmployeePayrollOperations employeePayrolloperations = new EmployeePayrollOperations();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            employeePayrolloperations.AddEmployeeToPayroll(employeeDetails);
            stopwatch.Stop();
            Console.WriteLine("Duration without thread" + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("-------");
        }
    }
}
