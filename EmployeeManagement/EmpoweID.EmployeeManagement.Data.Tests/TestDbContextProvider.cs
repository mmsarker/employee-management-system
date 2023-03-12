using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Data.Tests
{
    public static class TestDbContextProvider
    {
        public static EmployeeDbContext GetEmployeeDbContext()
        {
            var optionBuilder = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());

            return new EmployeeDbContext(optionBuilder.Options);
        }
    }
}
