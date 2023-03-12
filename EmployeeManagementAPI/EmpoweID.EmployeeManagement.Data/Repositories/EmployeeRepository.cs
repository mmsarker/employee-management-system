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

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await this._employeeDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await this._employeeDbContext.Employees.FindAsync(id);
        }

        public Task<List<Employee>> GetEmployeesAsync(string? name, string? email, string? department)
        {
            IQueryable<Employee> employees = this._employeeDbContext.Employees.Include("Department");

            if (!string.IsNullOrEmpty(name))
            {
                employees = employees.Where(x => x.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(email))
            {
                employees = employees.Where(x => x.Email.Contains(email));
            }

            if (!string.IsNullOrEmpty(department))
            {
                employees = employees.Where(x => x.Department.Name.Contains(department));
            }

            return employees.ToListAsync();
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            this._employeeDbContext.Employees.Add(employee);
            await this._employeeDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employee = this._employeeDbContext.Employees.Find(id);
            if (employee != null)
            {
                this._employeeDbContext.Remove(employee);
                await this._employeeDbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            this._employeeDbContext.Attach(employee);
            this._employeeDbContext.Entry(employee).State = EntityState.Modified;
            await this._employeeDbContext.SaveChangesAsync();
            return employee;
        }
    }
}
