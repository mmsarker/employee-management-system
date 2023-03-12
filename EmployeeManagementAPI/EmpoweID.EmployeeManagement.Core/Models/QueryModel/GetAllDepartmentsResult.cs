using EmpoweID.EmployeeManagement.Core.Infrastructure;
using EmpoweID.EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Core.Model
{
    public class GetAllDepartmentsQueryResult : IQueryResult
    {
        public List<DepartmentResponseModel> Departments { get; set; }
    }

    public class DepartmentResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
