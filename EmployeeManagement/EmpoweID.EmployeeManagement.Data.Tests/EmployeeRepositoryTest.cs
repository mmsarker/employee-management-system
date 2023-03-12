using EmpoweID.EmployeeManagement.Data.Entities;
using EmpoweID.EmployeeManagement.Data.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EmpoweID.EmployeeManagement.Data.Tests
{
    public class EmployeeRepositoryTest
    {   
        [Fact]
        public async Task GetAllEmployees_Should_Return_Employees()
        {
            var dbContext = TestDbContextProvider.GetEmployeeDbContext();
            dbContext.Employees.Add(new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Employee 1",
                Email = "test@testemployeeaasas.com",
                DateOfBirth = new DateTime(1990,1,1),
                Department = new Department
                {
                    Id= Guid.NewGuid(),
                    Name ="Department One"
                }                
            });

            dbContext.SaveChanges();

            var employeeRepository = new EmployeeRepository(dbContext);
            var employees = await employeeRepository.GetAllEmployees();
            Assert.NotNull(employees);
            Assert.Equal(1, employees.Count);
            
        }
    }
}