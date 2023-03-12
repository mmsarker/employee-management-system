using EmpoweID.EmployeeManagement.Core.CommandHandlers;
using EmpoweID.EmployeeManagement.Core.Infrastructure;
using EmpoweID.EmployeeManagement.Core.Model;
using EmpoweID.EmployeeManagement.Core.QueryHandlers;
using EmpoweID.EmployeeManagement.Data.Repositories;

namespace EmpoweID.EmployeeManagementApi
{
    public static class Registrations
    {
        public static void RegisterEmployeeManagemntServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IQueryHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult>, GetEmployeeByIdQueryHandler>();
            services.AddScoped<IQueryHandler<SearchEmployeeQuery, SearchEmployeeQueryResult>, SearchEmployeeQueryHandler>();
            services.AddScoped<ICommandHandler<AddEmployeeRequest, AddEmployeeResult>, AddEmployeeCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateEmployeeRequest, CommandResult>, UpdateEmployeeCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteEmployeeRequest, CommandResult>, DeleteEmployeeCommandHandler>();
        }
    }
}
