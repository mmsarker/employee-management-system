using EmpoweID.EmployeeManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            this._employeeDbContext = employeeDbContext;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await this._employeeDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await this._employeeDbContext.Employees.FindAsync(id);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            this._employeeDbContext.Employees.Add(employee);
            await this._employeeDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = this._employeeDbContext.Employees.Find(id);
            if (employee != null)
            {
                this._employeeDbContext.Remove(employee);
                await this._employeeDbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            this._employeeDbContext.Attach(employee);
            await this._employeeDbContext.SaveChangesAsync();
            return employee;
        }
    }
}
