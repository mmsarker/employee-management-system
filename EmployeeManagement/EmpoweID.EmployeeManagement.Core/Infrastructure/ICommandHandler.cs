using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweID.EmployeeManagement.Core.Infrastructure
{
    public interface ICommandHandler<in T1, T2> where T1 : ICommand where T2 : ICommandResult
    {
        ValueTask<T2> HandleAsync(T1 command);
    }
}
