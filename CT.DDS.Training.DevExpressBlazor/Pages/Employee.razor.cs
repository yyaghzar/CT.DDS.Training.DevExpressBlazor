using CT.DDS.Training.DevExpressBlazor.Services;
using CT.DDS.Training.DevExpressBlazor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.DDS.Training.DevExpressBlazor.Pages
{
    //[Authorize(Roles ="admin")]
    public class EmployeeBase : ComponentBase
    {
        [Inject]
        protected IEmployeeDataService employeeDataService { get; set; }

        [Parameter]
        public IEnumerable<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();

        protected async override Task OnInitializedAsync()
        {
            var results = await employeeDataService.GetEmployees();
            Employees = results;


        }
    }
}
