using CT.DDS.Training.DevExpressBlazor.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.DDS.Training.Blazor.EmployeeApi.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    BirthDate = new DateTime(1980, 1, 16),
                    FirstName = "Bethany",
                    LastName = "Smith",
                    Gender = Gender.Female,
                    ExitDate = null,
                    JoinedDate = new DateTime(2005, 10, 15),
                    Title = Title.Accountant

                },
                new Employee()
                {
                    Id = 2,
                    BirthDate = new DateTime(1979, 1, 16),
                    FirstName = "Bob",
                    LastName = "Cooper",
                    Gender = Gender.Male,         
                    ExitDate = null,
                    JoinedDate = new DateTime(2015, 3, 1),
                    Title = Title.Engineer
                },
                new Employee()
                {
                    Id = 3,
                    BirthDate = new DateTime(1970, 1, 16),
                    FirstName = "Frank",
                    LastName = "Jones",
                    Gender = Gender.Male,
                    ExitDate = null,
                    JoinedDate = new DateTime(1990, 12, 5),
                    Title = Title.TechSupport
                },
                new Employee()
                {
                    Id = 4,
                    BirthDate = new DateTime(1989, 4, 20),
                    FirstName = "Claire",
                    LastName = "Smith",
                    Gender = Gender.Female,
                    ExitDate = null,
                    JoinedDate = new DateTime(2019, 10, 8),
                    Title = Title.HrSpecialit
                }
            });

        }
    }
}
