using ManageEmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ManageEmployeeApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Server=.\\SQLEXPRESS01;Database=EmployeeDB;User Id=sa;Password=Araj1901@;");
            options.UseSqlServer("Server=.\\SQLEXPRESS01;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeSalary)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.EmployeeId);
        }
    }
}
