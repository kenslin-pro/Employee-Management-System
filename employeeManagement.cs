using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Employee
{
  public int EmployeeId { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Department { get; set; }
  public decimal Salary { get; set; }
}

class Program
{
  static List<Employee> employees = new List<Employee>();
  static int nextEmployeeId = 1;


  //display the system to the user

  static void Main()
  {
    while (true)
    {
      Console.WriteLine("\nEmployee Management System");
      Console.WriteLine("1. Add Employee");
      Console.WriteLine("2. Edit Employee");
      Console.WriteLine("3. Display Employees");
      Console.WriteLine("4. Exit");
      Console.Write("Enter your choice: ");

      if (int.TryParse(Console.ReadLine(), out int choice))
      {
        switch (choice)
        {
          case 1:
            AddEmployee();
            break;
          case 2:
            EditEmployee();
            break;
          case 3:
            DisplayEmployees();
            break;
          case 4:
            Environment.Exit(0);
            break;
          default:


            // when the user enters invalid choice
            Console.WriteLine("Invalid choice. Please try again.");
            break;
        }
      }

      // when the user enters invalid choice
      else
      {
        Console.WriteLine("Invalid input. Please enter a number.");
      }
    }
  }


  // allow the user to enter employee details

  static void AddEmployee()
  {
    Employee employee = new Employee();
    employee.EmployeeId = nextEmployeeId++;
    Console.Write("Enter First Name: ");
    employee.FirstName = Console.ReadLine();
    Console.Write("Enter Last Name: ");
    employee.LastName = Console.ReadLine();
    Console.Write("Enter Department: ");
    employee.Department = Console.ReadLine();
    Console.Write("Enter Salary: ");
    if (decimal.TryParse(Console.ReadLine(), out decimal salary))
    {
      employee.Salary = salary;
      employees.Add(employee);
      Console.WriteLine("Employee added successfully.");
    }
    else
    {
      Console.WriteLine("Invalid salary input. Employee not added.");
    }
  }

  static void EditEmployee()
  {
    Console.Write("Enter Employee ID to edit: ");
    if (int.TryParse(Console.ReadLine(), out int employeeId))
    {
      Employee employee = employees.Find(e => e.EmployeeId == employeeId);
      if (employee != null)
      {
        Console.Write("Enter new Salary: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal salary))
        {
          employee.Salary = salary;
          Console.WriteLine("Employee details updated successfully.");
        }
        else
        {
          Console.WriteLine("Invalid salary input. Employee details not updated.");
        }
      }
      else
      {
        Console.WriteLine("Employee not found with the given ID.");
      }
    }
    else
    {
      Console.WriteLine("Invalid employee ID input.");
    }
  }


  // display employees details to the user

  static void DisplayEmployees()
  {
    Console.WriteLine("\nEmployee Details:");
    foreach (var employee in employees)
    {
      Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}, Salary: {employee.Salary:C}");
    }
  }
}

