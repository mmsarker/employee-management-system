using EmpoweID.EmployeeManagement.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Core.Model
{
    public class DeleteEmployeeRequest : ICommand
    {
        public Guid Id { get; set; }        
    }
}