using CT.DDS.Training.DevExpressBlazor.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CT.DDS.Training.DevExpressBlazor.Services
{
    public class EmployeeDataService: IEmployeeDataService
    {
        private readonly IHttpClientFactory _clientFactory;
        public EmployeeDataService(IHttpClientFactory ClientFactory)
        {
            _clientFactory = ClientFactory;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees() {
            var client = _clientFactory.CreateClient("employeeApi");
            return await client.GetJsonAsync<IEnumerable<EmployeeDTO>>("Employee");
        }
    }
}
