using System;
using System.Collections.Generic;
using System.Globalization;

namespace exercicioListas
{
    class Program
    {
        static void Main(string[] args)
        {
            List < Employee > employeesList = new List<Employee>();
            Console.Write("How many employees will be registered? ");
            int employeesQuantity = int.Parse(Console.ReadLine());
            for(int i = 1; i <= employeesQuantity; i++)
            {
                Console.WriteLine($"Emplyoee #{i}:");
                employeesList.Add(getEmployeeInfo());
                Console.WriteLine();
            }

            Console.Write("Enter the employee id that will have salary increase : ");
            int searchId = int.Parse(Console.ReadLine());
            Employee emp = employeesList.Find(x => x.id == searchId);
            if (emp != null)
            {
                Console.Write("Enter the percentage: ");
                double percentage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                emp.increaseSalary(percentage);
            }
            else
            {
                Console.WriteLine("This id does not exist!");
            }

            printList(employeesList);

        }

        static Employee getEmployeeInfo()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            return new Employee(id, name, salary);
        }

        static void printList(List<Employee> employeesList)
        {
            foreach(Employee employee in employeesList)
            {
                Console.WriteLine(employee);
            }
        }
        
    }
}
