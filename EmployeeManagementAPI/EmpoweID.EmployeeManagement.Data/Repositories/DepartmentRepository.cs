using EmpoweID.EmployeeManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public DepartmentRepository(EmployeeDbContext employeeDbContext)
        {
            this._employeeDbContext = employeeDbContext;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await this._employeeDbContext.Departments.ToListAsync();
        }
    }
}
