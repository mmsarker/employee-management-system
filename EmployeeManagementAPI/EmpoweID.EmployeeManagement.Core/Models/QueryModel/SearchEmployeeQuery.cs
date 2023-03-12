using EmpoweID.EmployeeManagement.Core.Infrastructure;
using EmpoweID.EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Core.Model
{
    public class SearchEmployeeQuery : IQuery
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }        
    }
}
