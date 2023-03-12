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
    public class GetAllDepartmentsQueryHandler : IQueryHandler<GetAllDepartmentsQuery, GetAllDepartmentsQueryResult>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        public async ValueTask<GetAllDepartmentsQueryResult> GetDataAsync(GetAllDepartmentsQuery query)
        {
            var departments = await this._departmentRepository.GetDepartmentsAsync();
            return new GetAllDepartmentsQueryResult
            {
                Departments = departments.Select(x => new DepartmentResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList()
            };
        }
    }
}
