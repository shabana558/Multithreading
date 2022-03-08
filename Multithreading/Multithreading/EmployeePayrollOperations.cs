using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    public class EmployeePayrollOperations
    {
        public List<EmployeeDetails> employeePayrollDetailList=new List<EmployeeDetails>();
        public List<EmployeeDetails> employeePayrollDetailListwithThread = new List<EmployeeDetails>();

        public void AddEmployeeToPayroll(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                this.AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee added:" + employeeData.EmployeeName);
            });
            Console.WriteLine(this.employeePayrollDetailList.Count);
            Thread thr = Thread.CurrentThread;
            //thr.Name="Thread1";
            //Console.WriteLine("The name of the current " +"thread is:"+ thr.Name);
            Console.WriteLine("Thread:" + thr.ManagedThreadId);
            Console.WriteLine();
        }
        public void AddEmployeeToPayrollWithThread(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Thread thread = new Thread(() =>
                  {
                      Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                      this.AddEmployeePayroll(employeeData);
                      Console.WriteLine("Employee added:" + employeeData.EmployeeName);
                  });
                thread.Start();
                Console.WriteLine("Thread:" + thread.ManagedThreadId);
            });
        }
        public void AddEmployeePayroll(EmployeeDetails emp)
        {
            employeePayrollDetailList.Add(emp);
        }
        public int EmployeeCount()
        {
            return this. employeePayrollDetailList.Count;
        }
    }
}
