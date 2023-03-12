using EmployeeManagemntWeb.Infrastructure;
using EmployeeManagemntWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagemntWeb.Pages.Employees
{
    public class EmployeeListModel : PageModel
    {
        [BindProperty]
        public EmployeeListViewModel employeeListViewModel { get; set; }

        [BindProperty(SupportsGet =true)]
        public string? SearchName { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? SearchEmail { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? SearchDepartmentName { get; set; }

        private IGenericHttpClient _genericHttpClient;
        public EmployeeListModel(IConfiguration configuration)
        {
            _genericHttpClient = new GenericHttpClient(configuration);
        }

        public async Task OnGet()
        {
            employeeListViewModel = await this._genericHttpClient.GetAsync<EmployeeListViewModel>
                ($"employees/search?name={SearchName}&email={SearchEmail}&department={SearchDepartmentName}");

        }
    }
}
