﻿using EmpoweID.EmployeeManagement.Core.Infrastructure;
using EmpoweID.EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Core.Model
{
    public class SearchEmployeeQueryResult : IQueryResult
    {
        public List<Employee> Employees { get; set; }
    }
}
