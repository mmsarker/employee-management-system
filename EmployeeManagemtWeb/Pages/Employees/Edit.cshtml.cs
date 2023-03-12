using EmployeeManagemntWeb.Infrastructure;
using EmployeeManagemntWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagemntWeb.Pages.Employees
{
    public class EditEmployeeModel : PageModel
    {
        private IGenericHttpClient _genericHttpClient;
        [BindProperty]
        public EmployeeViewModel EditEmployeeViewModel { get; set; }

        [BindProperty]
        public List<SelectListItem> Departments { get; set; }

        public EditEmployeeModel(IConfiguration configuration)
        {
            _genericHttpClient = new GenericHttpClient(configuration);
        }

        public async Task OnGet(Guid id)
        {
            var getEmployeeByIDViewModel = await this._genericHttpClient.GetAsync<GetEmployeeByIDViewModel>($"Employees/{id}");
            this.EditEmployeeViewModel = getEmployeeByIDViewModel.Employee;
            var departmentListViewModel = await this._genericHttpClient.GetAsync<DepartmentListViewModel>("departments");
            Departments = departmentListViewModel.Departments.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }
        
        public async Task OnPostUpdate(Guid id)
        {            
            //EditEmployeeViewModel.Id= id;
            await this._genericHttpClient.PutAsync<EmployeeViewModel>($"Employees/{id}", EditEmployeeViewModel);
            Response.Redirect("/Employees/Index");
        }

        public async Task OnDeleteUpdate(Guid id)
        {
            await this._genericHttpClient.DeleteAsync($"Employees/{id}");
            Response.Redirect("/Employees/Index");
        }
    }
}
