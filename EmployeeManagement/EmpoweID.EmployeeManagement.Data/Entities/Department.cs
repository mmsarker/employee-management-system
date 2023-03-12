using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Data.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
