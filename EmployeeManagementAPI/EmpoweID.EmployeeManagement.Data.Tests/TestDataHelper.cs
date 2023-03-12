using EmpoweID.EmployeeManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Data.Tests
{
    public static class TestDataHelper
    {
        public static EmployeeDbContext GetEmployeeDbContext()
        {
            var optionBuilder = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());

            return new EmployeeDbContext(optionBuilder.Options);
        }


        public static Employee CreateNewEmployee()
        {
            return new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Employee 1",
                Email = "test@testemployeeaasas.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = new Department
                {
                    Id = Guid.NewGuid(),
                    Name = "Department One"
                }
            };
        }
    }
}
