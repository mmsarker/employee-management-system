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
            var dbContext = TestDataHelper.GetEmployeeDbContext();
            TestDataHelper.CreateNewEmployee("Test1", "department1");

            dbContext.SaveChanges();

            var employeeRepository = new EmployeeRepository(dbContext);
            var employees = await employeeRepository.GetAllEmployeesAsync();
            Assert.NotNull(employees);
            Assert.Equal(1, employees.Count);

        }

        [Fact]
        public async Task AddEmployee_Shoud_Create_New_employee()
        {
            var dbContext = TestDataHelper.GetEmployeeDbContext();
            var employeerepository = new EmployeeRepository(dbContext);
            var employee = TestDataHelper.CreateNewEmployee("Test1", "department1");

            await employeerepository.AddEmployeeAsync(employee);

            var employeeDb = await dbContext.Employees.FindAsync(employee.Id);
            Assert.NotNull(employeeDb);
        }

        [Fact]
        public async Task GetEmployeesAsync_Shoud_Filter_By_Name()
        {
            var dbContext = TestDataHelper.GetEmployeeDbContext();
            var employee1 = TestDataHelper.CreateNewEmployee("Test1", "department1");
            var employee2 = TestDataHelper.CreateNewEmployee("Best2", "department2");
            dbContext.Employees.Add(employee1);
            dbContext.Employees.Add(employee2);
            dbContext.SaveChanges();

            var employeerepository = new EmployeeRepository(dbContext);
            var response = await employeerepository.GetEmployeesAsync("Test1", null, null);
            Assert.NotNull(response);
            Assert.Equal(response.Count, 1);
        }

        [Fact]
        public async Task GetEmployeesAsync_Shoud_Filter_By__Department_Name()
        {
            var dbContext = TestDataHelper.GetEmployeeDbContext();
            var employee1 = TestDataHelper.CreateNewEmployee("Test1", "department1");
            var employee2 = TestDataHelper.CreateNewEmployee("Best2", "department2");
            dbContext.Employees.Add(employee1);
            dbContext.Employees.Add(employee2);
            dbContext.SaveChanges();

            var employeerepository = new EmployeeRepository(dbContext);
            var response = await employeerepository.GetEmployeesAsync(null, "Department2", null);
            Assert.NotNull(response);
            Assert.Equal(response.Count, 1);
        }
    }
}