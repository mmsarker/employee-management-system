using EmpoweID.EmployeeManagement.Core.Infrastructure;
using EmpoweID.EmployeeManagement.Core.Model;
using EmpoweID.EmployeeManagement.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmpoweID.EmployeeManagementApi.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : Controller
    {
        private readonly IQueryHandler<GetAllDepartmentsQuery, GetAllDepartmentsQueryResult> _getAllDepartmentsQueryHandler;

        public DepartmentController(IQueryHandler<GetAllDepartmentsQuery, GetAllDepartmentsQueryResult> getAllDepartmentsQueryHandler)
        {
            this._getAllDepartmentsQueryHandler = getAllDepartmentsQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departments = await this._getAllDepartmentsQueryHandler.GetDataAsync(new GetAllDepartmentsQuery());
            return Ok(departments);
        }
    }
}
