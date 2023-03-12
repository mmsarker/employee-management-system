using EmpoweID.EmployeeManagement.Core.Infrastructure;
using EmpoweID.EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Core.Model
{
    public class SearchEmployeeQueryResult : IQueryResult
    {
        public List<EmployeeResponseModel> Employees { get; set; }
    }

    public class EmployeeResponseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string DepartmentName { get; set; }

        public Guid DepartmentId { get; set; }
    }
}
