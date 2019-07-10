using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public abstract class Employee
    {
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected string Designation { get; set; }
        protected int ExperienceInYear { get; set; }
        protected int AnnualSalary { get; set; }
        protected int JoiningDate { get; set; }

        public abstract void EmployeeDetails();
        public abstract int SalaryCalculation();     // abstract method
    }
}
