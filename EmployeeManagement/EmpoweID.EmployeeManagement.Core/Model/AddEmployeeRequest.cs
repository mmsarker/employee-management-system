using EmpoweID.EmployeeManagement.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Core.Model
{
    public class AddEmployeeRequest : ICommand
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }        

        public Guid DepartmentId { get; set; }
    }
}
