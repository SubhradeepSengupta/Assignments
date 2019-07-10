using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Your ID : ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter Your Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Please Enter Your Department name : ");
            string dept = Console.ReadLine();

            //object instance
            Employee EmpObj = new Employee(id, name, dept);
            EmpObj.MethodCalled += new MethodCallEvent(MethodCallededString);

            //method invocation through object
            Console.WriteLine("Employee Id : " + EmpObj.GetId());
            Console.WriteLine("Employee Name : " + EmpObj.GetName());
            Console.WriteLine("Employee Department name : " + EmpObj.GetDepartmentName());
            Console.WriteLine("===================================================");

            //new details
            Console.WriteLine("Please Enter Your New ID : ");
            int newId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter Your New Name : ");
            string newName = Console.ReadLine();
            Console.WriteLine("Please Enter Your New Department name : ");
            string newDept = Console.ReadLine();

            Console.WriteLine("New Employee Id : " + EmpObj.GetId(newId));
            Console.WriteLine("New Employee Name : " + EmpObj.GetName(newName));
            Console.WriteLine("New Employee Department name : " + EmpObj.GetDepartmentName(newDept));
        }

        static void MethodCallededString(string value)
        {
            Console.WriteLine(value);
        }
    }
}
