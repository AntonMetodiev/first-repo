﻿using FirmDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmDb.Presentation
{
    public class Display
    {
        private int closeOperationId = 6;
        private FirmBusiness firmBusiness = new FirmBusiness();

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
        public Display()
        {
            Input();
        }
        private void Add()
        {
            Employee employee = new Employee();

            Console.WriteLine("Enter first name: ");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Enter town: ");
            employee.Town = Console.ReadLine();
            Console.WriteLine("Enter salary: ");
            employee.Salary = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter department name: ");
            employee.DepartmentName = Console.ReadLine();

            firmBusiness.Add(employee);
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Employees" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var products = firmBusiness.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} {item.Town} {item.Salary} {item.DepartmentName}");
            }
        }
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = firmBusiness.Get(id);
            if (employee != null)
            {
                Console.WriteLine("Enter first name: ");
                employee.FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                employee.LastName = Console.ReadLine();
                Console.WriteLine("Enter town: ");
                employee.Town = Console.ReadLine();
                Console.WriteLine("Enter salary: ");
                employee.Salary = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter department name: ");
                employee.DepartmentName = Console.ReadLine();

                firmBusiness.Update(employee);
            }
            else
            {
                Console.WriteLine("Employee not found!");
            }
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = firmBusiness.Get(id);
            if (employee != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + employee.Id);
                Console.WriteLine("First name: " + employee.FirstName);
                Console.WriteLine("Last name: " + employee.LastName);
                Console.WriteLine("Town: " + employee.Town);
                Console.WriteLine("Salary: " + employee.Salary);
                Console.WriteLine("Department name: " + employee.DepartmentName);
                Console.WriteLine(new string('-', 40));
            }
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            firmBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
