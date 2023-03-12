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

        private IGenericHttpClient _genericHttpClient;
        public EmployeeListModel(IConfiguration configuration)
        {
            _genericHttpClient = new GenericHttpClient(configuration);
        }

        public async Task OnGet()
        {
            employeeListViewModel = await this._genericHttpClient.GetAsync<EmployeeListViewModel>("employees/search");

        }
    }
}
