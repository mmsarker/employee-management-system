using EmpoweID.EmployeeManagement.Core.Infrastructure;
using EmpoweID.EmployeeManagement.Core.Model;
using EmpoweID.EmployeeManagement.Data.Repositories;

namespace EmpoweID.EmployeeManagementApi
{
    public static class Registrations
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IQueryHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult>>();
            services.AddScoped<IQueryHandler<SearchEmployeeQuery, SearchEmployeeQueryResult>>();
            services.AddScoped<ICommandHandler<AddEmployeeRequest, AddEmployeeResult>>();
            services.AddScoped<ICommandHandler<UpdateEmployeeRequest, CommandResult>>();
            services.AddScoped<ICommandHandler<DeleteEmployeeRequest, CommandResult>>();
        }
    }
}
