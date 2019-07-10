using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Assignment6;

public class Program
{
    IList<Employee> employeeList;
    IList<Salary> salaryList;

    public Program()
    {
        employeeList = new List<Employee>() {
            new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
            new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
            new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
            new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
            new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
            new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
            new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}
        };

        salaryList = new List<Salary>() {
            new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
        };
    }

    public static void Main()
    {
        Program program = new Program();

        program.Task1();

        program.Task2();

        program.Task3();
    }

    public void Task1()
    {
        var query1 = from employees in employeeList
                     join salary in salaryList
                     on employees.EmployeeID equals salary.EmployeeID into EmpGrp
                     select new
                     {
                         FirstName = employees.EmployeeFirstName,
                         LastName = employees.EmployeeLastName,
                         Sum = EmpGrp.Sum(s => s.Amount)
                     };


        Console.WriteLine("Total salary Of All The Employee in ascending order of their salary : ");
        Console.WriteLine();
        foreach (var emps in query1.OrderBy(s => s.Sum))
        {
            Console.WriteLine($"Employee Name : " +
                              $"{emps.FirstName} " +
                              $"{emps.LastName} " +
                              $"  Employee Salary : {emps.Sum}");
        }
        Console.WriteLine();
    }

    public void Task2()
    {
        var query1 = from employees in employeeList
                     join salary in salaryList.Where(s => s.Type == SalaryType.Monthly)
                     on employees.EmployeeID equals salary.EmployeeID into EmpGrp
                     select new
                     {
                         EmployeeId = employees.EmployeeID,
                         FirstName = employees.EmployeeFirstName,
                         LastName = employees.EmployeeLastName,
                         EmployeeAge = employees.Age,
                         Sum = EmpGrp.Sum(s => s.Amount)
                     };

        Console.WriteLine("Employee details of 2nd oldest employee including his/her total monthly salary : ");
        Console.WriteLine();
        foreach (var emps in query1.OrderByDescending(a => a.EmployeeAge).Skip(1).Take(1))
        {
            Console.WriteLine($"Employee Id : {emps.EmployeeId} " +
                              $"Employee Name : " +
                              $"{emps.FirstName} " +
                              $"{emps.LastName} " +
                              $"Employee Age : {emps.EmployeeAge} " +
                              $"Employee Total Monthly Salary : {emps.Sum}");
        }
        Console.WriteLine();
    }

    public void Task3()
    {
        var query1 = from employees in employeeList.Where(e => e.Age > 30)
                     join salary in salaryList
                     on employees.EmployeeID equals salary.EmployeeID into EmpGrp
                     select new
                     {
                         Id = employees.EmployeeID,
                         Name = employees.EmployeeFirstName,
                         EmployeeAge = employees.Age,
                         Avg = EmpGrp.Average(s => s.Amount)
                     } into results
                     select results;

        Console.WriteLine("Mean of Monthly, Performance, Bonus salary of employees with age greater than 30 : ");
        Console.WriteLine();
        foreach (var emps in query1)
        {
            Console.WriteLine($"Employee Id : {emps.Id}  Employee Name : {emps.Name}  Employee Age : {emps.EmployeeAge}  Employee Salary Average : {emps.Avg}");
        }
    }
}

public enum SalaryType
{
    Monthly,
    Performance,
    Bonus
}






