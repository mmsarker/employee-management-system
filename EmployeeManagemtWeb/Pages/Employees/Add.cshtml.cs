using EmployeeManagemntWeb.Infrastructure;
using EmployeeManagemntWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagemntWeb.Pages.Employees
{
    public class AddEmployeeModel : PageModel
    {
        private IGenericHttpClient _genericHttpClient;

        [BindProperty]
        public AddEmployeeViewModel addEmployeeViewModel { get; set; }

        [BindProperty]
        public List<SelectListItem> Departments { get; set; }

        public AddEmployeeModel(IConfiguration configuration)
        {
            _genericHttpClient = new GenericHttpClient(configuration);
        }

        public async Task OnGet()
        {
            var departmentListViewModel = await this._genericHttpClient.GetAsync<DepartmentListResponse>("departments");
            Departments = departmentListViewModel.Departments.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        public async Task OnPost()
        {
            var response =  await _genericHttpClient.PostAsync<AddEmployeeViewModel, AddEmployeeResponseModel>("employees", addEmployeeViewModel);
            Response.Redirect("/Employees/Index");
        }
    }
}
