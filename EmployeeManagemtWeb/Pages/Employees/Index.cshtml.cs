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
            var baseUrl = configuration.GetSection("BaseAPIURL").Value;
            _genericHttpClient = new GenericHttpClient(baseUrl);
        }
        
        public async Task OnGet()
        {
            employeeListViewModel = await this._genericHttpClient.GetAsync<EmployeeListViewModel>("employee/search");

        }
    }
}
