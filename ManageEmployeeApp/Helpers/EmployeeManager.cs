using ManageEmployeeApp.Data;
using ManageEmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEmployeeApp.Helpers
{
    public static class EmployeeManager
    {
        public static void ListEmployees(string filter = null)
        {
            using var db = new AppDbContext();

            var employees = db.Employees
                .Include(e => e.EmployeeSalary)
                .ToList() // Brings everything into memory so C# can safely handle it
                .Where(e =>
                    string.IsNullOrEmpty(filter) ||
                    e.Name.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                    e.EmployeeSalary.OrderByDescending(s => s.ToDate)
                              .FirstOrDefault()?.Title.Contains(filter, StringComparison.OrdinalIgnoreCase) == true
                )
                .Select(e => new
                {
                    e.Name,
                    Title = e.EmployeeSalary.OrderByDescending(s => s.ToDate).FirstOrDefault()?.Title ?? "N/A",
                    Salary = e.EmployeeSalary.OrderByDescending(s => s.ToDate).FirstOrDefault()?.Salary ?? 0
                });

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Name} - {emp.Title} - ${emp.Salary}");
            }
        }

        public static void ListTitles()
        {
            using var db = new AppDbContext();
            var titles = db.EmployeeSalary
                .GroupBy(s => s.Title)
                .Select(g => new
                {
                    Title = g.Key,
                    MinSalary = g.Min(s => s.Salary),
                    MaxSalary = g.Max(s => s.Salary)
                });

            foreach (var t in titles)
                Console.WriteLine($"{t.Title} - Min: ${t.MinSalary}, Max: ${t.MaxSalary}");
        }

        public static void AddEmployee()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("SSN: ");
            string ssn = Console.ReadLine();
            Console.Write("DOB (yyyy-mm-dd): ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("State: ");
            string state = Console.ReadLine();
            Console.Write("Zip: ");
            string zip = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Join Date (yyyy-mm-dd): ");
            DateTime joinDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            using var db = new AppDbContext();

            var emp = new Employee
            {
                Name = name,
                SSN = ssn,
                DOB = dob,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                Phone = phone,
                JoinDate = joinDate
            };

            db.Employees.Add(emp);
            db.SaveChanges();

            var empSalary = new EmployeeSalary
            {
                EmployeeId = emp.Id,
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddYears(1),
                Title = title,
                Salary = salary
            };

            db.EmployeeSalary.Add(empSalary);
            db.SaveChanges();

            Console.WriteLine("Employee added successfully.");
        }
    }
}
