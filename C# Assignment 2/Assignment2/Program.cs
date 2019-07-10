using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            // object creation
            Developer DeveloperObject = new Developer();
            HR HRObject = new HR();

            HRObject.EmployeeDetails();
            Console.WriteLine(HRObject.SalaryCalculation());

            DeveloperObject.EmployeeDetails();
            Console.WriteLine(DeveloperObject.SalaryCalculation());
        }
    }
}
