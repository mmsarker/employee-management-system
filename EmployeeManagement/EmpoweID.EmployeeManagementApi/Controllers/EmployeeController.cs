using EmpoweID.EmployeeManagement.Core.Infrastructure;
using EmpoweID.EmployeeManagement.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmpoweID.EmployeeManagementApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class EmployeeController : Controller
    {
        private readonly IQueryHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult> _getEmployeeByIdQueryHandler;
        private readonly IQueryHandler<SearchEmployeeQuery, SearchEmployeeQueryResult> _searchEmployeeQueryHandler;
        private readonly ICommandHandler<AddEmployeeRequest, AddEmployeeResult> _addEmployeeCommandHandler;
        private readonly ICommandHandler<UpdateEmployeeRequest, CommandResult> _updateEmployeeCommandHandler;

        public EmployeeController(IQueryHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult> getEmployeeByIdQueryHandler,
            IQueryHandler<SearchEmployeeQuery, SearchEmployeeQueryResult> searchEmployeeQueryHandler,
            ICommandHandler<AddEmployeeRequest, AddEmployeeResult> addEmployeeCommandHandler,
            ICommandHandler<UpdateEmployeeRequest, CommandResult> updateEmployeeCommandHandler)
        {
            this._getEmployeeByIdQueryHandler = getEmployeeByIdQueryHandler;
            this._searchEmployeeQueryHandler = searchEmployeeQueryHandler;
            this._addEmployeeCommandHandler = addEmployeeCommandHandler;
            this._updateEmployeeCommandHandler = updateEmployeeCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetEmployeeByIdQuery query)
        {
            var employeeResult = await this._getEmployeeByIdQueryHandler.GetDataAsync(query);

            if (employeeResult == null || employeeResult.Employee == null)
            {
                return NotFound();
            }

            return Ok(employeeResult);
        }

        [HttpGet]
        public async Task<IActionResult> searchEmployees([FromQuery] SearchEmployeeQuery query)
        {
            var employeeResult = await this._searchEmployeeQueryHandler.GetDataAsync(query);
            return Ok(employeeResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            var response = await this._addEmployeeCommandHandler.HandleAsync(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] UpdateEmployeeRequest request)
        {

            var response = await this._updateEmployeeCommandHandler.HandleAsync(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id, [FromBody] UpdateEmployeeRequest request)
        {

            var response = await this._updateEmployeeCommandHandler.HandleAsync(request);
            return Ok(response);
        }
    }
}
