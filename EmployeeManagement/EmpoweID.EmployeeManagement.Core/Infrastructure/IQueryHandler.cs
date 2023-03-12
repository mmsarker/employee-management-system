using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Core.Infrastructure
{
    public interface IQueryHandler<in T1, T2> where T1 : IQuery where T2 : IQueryResult
    {
        ValueTask<T2> GetDataAsync(T1 query);
    }
}
