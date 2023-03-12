using EmpoweID.EmployeeManagement.Core.Infrastructure;
using EmpoweID.EmployeeManagement.Core.Model;
using EmpoweID.EmployeeManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Core.QueryHandlers
{
    public class SearchEmployeeQueryHandler : IQueryHandler<SearchEmployeeQuery, SearchEmployeeQueryResult>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public SearchEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async ValueTask<SearchEmployeeQueryResult> GetDataAsync(SearchEmployeeQuery query)
        {
            var employees = await this._employeeRepository.GetEmployeesAsync(query.Name, query.Email, query.DepartmentName);
            return new SearchEmployeeQueryResult
            {
               Employees = employees
            };
        }
    }
}
