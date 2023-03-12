using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpoweID.EmployeeManagement.Core.Infrastructure;
using EmpoweID.EmployeeManagement.Core.Model;
using EmpoweID.EmployeeManagement.Data.Entities;
using EmpoweID.EmployeeManagement.Data.Repositories;

namespace EmpoweID.EmployeeManagement.Core.CommandHandlers
{
    public class AddEmployeeCommandHandler : ICommandHandler<AddEmployeeRequest, AddEmployeeResult>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async ValueTask<AddEmployeeResult> HandleAsync(AddEmployeeRequest command)
        {

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                DateOfBirth = command.DateOfBirth,
                DepartmentId = command.DepartmentId,
                Email = command.Email
            };

            await this._employeeRepository.AddEmployeeAsync(employee);
            return new AddEmployeeResult();
        }
    }
}