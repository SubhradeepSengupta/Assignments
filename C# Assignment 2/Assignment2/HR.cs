using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class HR : Employee
    {
        public override void EmployeeDetails()
        {
            Id = 2;
            Name = "DEF";
            Designation = "HR";
            ExperienceInYear = 4;
            AnnualSalary = 8000;
            JoiningDate = 17 / 5 / 2015;
        }

        public override int SalaryCalculation()
        {
            Console.WriteLine("HR's Salary :");
            return AnnualSalary + (1000 * ExperienceInYear);
        }
    }
}
