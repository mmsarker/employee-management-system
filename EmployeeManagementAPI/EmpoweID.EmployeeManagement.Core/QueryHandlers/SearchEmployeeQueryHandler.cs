﻿using EmpoweID.EmployeeManagement.Core.Infrastructure;
using EmpoweID.EmployeeManagement.Core.Model;
using EmpoweID.EmployeeManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Core.QueryHandlers
{
    public class SearchEmployeeQueryHandler : IQueryHandler<SearchEmployeeQuery, SearchEmployeeQueryResult>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public SearchEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async ValueTask<SearchEmployeeQueryResult> GetDataAsync(SearchEmployeeQuery query)
        {
            var employees = await this._employeeRepository.GetEmployeesAsync(query.Name, query.Email, query.Department);
            return new SearchEmployeeQueryResult
            {
                Employees = employees.Select(x => new EmployeeResponseModel
                {
                    Id = x.Id,
                    DateOfBirth = x.DateOfBirth,
                    DepartmentName = x.Department?.Name,
                    Email = x.Email,
                    DepartmentId = x.Department.Id,
                    Name = x.Name,
                }).ToList()
            };
        }
    }
}
