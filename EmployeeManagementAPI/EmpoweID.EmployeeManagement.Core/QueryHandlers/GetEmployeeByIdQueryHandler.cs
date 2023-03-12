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
    public class GetEmployeeByIdQueryHandler: IQueryHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult>
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async ValueTask<GetEmployeeByIdQueryResult> GetDataAsync(GetEmployeeByIdQuery query)
        {
            var employee = await this._employeeRepository.GetEmployeeByIdAsync(query.Id);
            return new GetEmployeeByIdQueryResult
            {
                Employee = employee
            };
        }
    }
}
