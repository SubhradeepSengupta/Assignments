using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Employee
    {
        private int Id { get; set; }
        private string Name { get; set; } 
        private string DepartmentName { get; set; }

    //parameterized constructor
    public Employee(int i, string n, string d)
        {
            Id = i;
            Name = n;
            DepartmentName = d;
        }

        //method for getting Id
        public int GetId()
        {
            MethodCalled("GetId() Method was called");
            return Id;
        }

        //method for getting Name
        public string GetName()
        {
            MethodCalled("GetName() Method was called");
            return Name;
        }

        //method for getting Department Name
        public string GetDepartmentName()
        {
            MethodCalled("GetDepartmentName() Method was called");
            return DepartmentName;
        }

        //overlaoded method for getting new Id
        public int GetId(int ID)
        {
            return ID;
        }

        //overloaded method for getting new Name
        public string GetName(string NAME)
        {
            // Console.Write(Name + " changed to " + NAME);
            return NAME;
        }

        //overlaoded method for getting new Department Name
        public string GetDepartmentName(string DEPARTMENT)
        {
            //Console.Write(DepartmentName + " changed to " + DEPARTMENT);
            return DEPARTMENT;
        }

        public event MethodCallEvent MethodCalled;
    }
}
