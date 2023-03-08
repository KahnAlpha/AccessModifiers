using System;
using System.Linq;

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter department name: ");
        var departmentName = Console.ReadLine();

        Console.Write("Enter maximum number of employees: ");
        var employeeLimit = int.Parse(Console.ReadLine());

        Console.Write("Enter maximum salary: ");
        var salaryLimit = decimal.Parse(Console.ReadLine());

        var department = new Department(departmentName, employeeLimit, salaryLimit);

        while (true)
        {
            Console.Write("Enter employee name (or 'quit' to exit): ");
            var name = Console.ReadLine();
            if (name.ToLower() == "quit")
            {
                break;
            }

            Console.Write("Enter employee surname: ");
            var surname = Console.ReadLine();

            Console.Write("Enter employee salary: ");
            var salary = decimal.Parse(Console.ReadLine());

            try
            {
                department.AddEmployee(name, surname, salary);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

class Employee
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public decimal Salary { get; private set; }

    public Employee(string name, string surname, decimal salary)
    {
        if (!IsNameValid(name))
        {
            Console.WriteLine("Name must contain only letters and begin with an uppercase letter.");
        }
        if (!IsNameValid(surname))
        {
            Console.WriteLine("Surname must contain only letters and begin with an uppercase letter.");
        }
        if (!IsSalaryValid(salary))
        {
            Console.WriteLine("Salary must be a number higher than 250 and must contain only numbers.");
        }
        Name = name;
        Surname = surname;
        Salary = salary;
    }

    public bool IsNameValid(string name)
    {
        return !string.IsNullOrEmpty(name) && char.IsUpper(name[0]) && name.Substring(1).All(char.IsLetter);
    }

    public bool IsSalaryValid(decimal salary)
    {
        return salary >= 250 && decimal.TryParse(salary.ToString(), out _);
    }
}

class Department
{
    public string Name { get; private set; }
    public int EmployeeLimit { get; private set; }
    public decimal SalaryLimit { get; private set; }
    private Employee[] employees;
    private int employeeCount;

    public Department(string name, int employeeLimit, decimal salaryLimit)
    {
        Name = name;
        EmployeeLimit = employeeLimit;
        SalaryLimit = salaryLimit;
        employees = new Employee[employeeLimit];
        employeeCount = 0;
    }

    public void AddEmployee(string name, string surname, decimal salary)
    {
        if (employeeCount >= EmployeeLimit)
        {
            Console.WriteLine("Department is full.");
        }
        if (employees.Sum(e => e?.Salary ?? 0) + salary > SalaryLimit)
        {
            Console.WriteLine("Employee salary exceeds department salary limit.");
        }
        while (true)
        {
            try
            {
                var employee = new Employee(name, surname, salary);
                employees[employeeCount++] = employee;
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("Please enter valid ");
                var emp = new Employee(name, surname, salary);
                if (!emp.IsNameValid(name))
                {
                    Console.Write("name: ");
                    name = Console.ReadLine();
                }
                else if (!emp.IsNameValid(surname))
                {
                    Console.Write("surname: ");
                    surname = Console.ReadLine();
                }
                else if (!emp.IsSalaryValid(salary))
                {
                    Console.Write("salary: ");
                    salary = decimal.Parse(Console.ReadLine());
                }
            }
        }
    }
}