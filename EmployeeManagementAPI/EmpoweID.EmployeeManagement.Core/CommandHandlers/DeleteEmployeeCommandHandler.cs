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
    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeRequest, CommandResult>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async ValueTask<CommandResult> HandleAsync(DeleteEmployeeRequest command)
        {
            var employee = this._employeeRepository.GetEmployeeByIdAsync(command.Id);
            
            if(employee == null)
            {
                throw new Exception("Not a valid Id");
            }

            await this._employeeRepository.DeleteEmployeeAsync(command.Id);
            return new CommandResult();
        }
    }
}