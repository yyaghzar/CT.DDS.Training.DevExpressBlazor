using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT.DDS.Training.Blazor.EmployeeApi.Models;
using CT.DDS.Training.DevExpressBlazor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CT.DDS.Training.Blazor.EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles ="admin")]
    public class EmployeeController : ControllerBase
    {
        

        private readonly ILogger<EmployeeController> _logger;
        private readonly AppDbContext _context;

        public EmployeeController(ILogger<EmployeeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await  _context.Employees.Select(x=> EmployeeToDTO(x)).ToListAsync();
            return Ok(employees);
        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetEmployeeById(int id) {
            var employee =await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(EmployeeToDTO(employee));
        }

        [HttpPut("id:int")]
        public async Task<ActionResult> UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {

            if (id != employeeDTO.Id)
            {
                return BadRequest();
            }

            var employee = DtoToEmployee(employeeDTO);

            if (!EmployeeExists(id))
            {
                return NotFound();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(EmployeeDTO employeeDTO) {

            var employee = DtoToEmployee(employeeDTO);

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, EmployeeToDTO(employee));

        }
        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteEmployee(int id) {

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        private bool EmployeeExists(int id) =>
         _context.Employees.Any(e => e.Id == id);

        private static EmployeeDTO EmployeeToDTO(Employee employee) =>
        new EmployeeDTO
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            ExitDate = employee.ExitDate,
            Gender = employee.Gender,
            JoinedDate = employee.JoinedDate,
            Title = employee.Title
        };
        private static Employee DtoToEmployee(EmployeeDTO employee) =>
        new Employee
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            ExitDate = employee.ExitDate,
            Gender = employee.Gender,
            JoinedDate = employee.JoinedDate,
            Title = employee.Title
        };

    }
}
