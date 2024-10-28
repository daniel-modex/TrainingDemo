using Microsoft.EntityFrameworkCore;
using AutomapperTutorial.Models;

namespace AutomapperTutorial.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AutomapperTutorial.Models.EmployeeDTO> EmployeeDTO { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    Age = 18,
                    Email = "adc@gmail.com",
                    Gender= "Male",
                    Name = "Daniel",
                    Salary = 100000,
                    SocialSecurityNumber = "daniel@acc"
                });
        }
    }
}
