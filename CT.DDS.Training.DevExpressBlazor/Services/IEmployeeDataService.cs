using CT.DDS.Training.DevExpressBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.DDS.Training.DevExpressBlazor.Services
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();
    }
}
