using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Developer : Employee
    {
        public override void EmployeeDetails()
        {
            Id = 1;
            Name = "ABC";
            Designation = "Developer";
            ExperienceInYear = 5;
            AnnualSalary = 8000;
            JoiningDate = 2 / 5 / 2014;
        }

        public override int SalaryCalculation()
        {
            Console.WriteLine("DEV's Salary :");
            return AnnualSalary + (2000* ExperienceInYear);
        }
    }
}
