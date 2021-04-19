using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPICRUDDemo.EmployeeData;
using RESTAPICRUDDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPICRUDDemo.Controllers
{
  
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("[controller]")]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }
        
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with the Id: {id} was not found");

        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,
                employee);

        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            var employee = _employeeData.GetEmployee(Id);
            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with the Id: {Id} was not found");
        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid Id,Employee employee)
        {
            var existingemployee = _employeeData.GetEmployee(Id);
            if (existingemployee != null)
            {
                employee.Id = existingemployee.Id;
                _employeeData.EditEmployee(employee);
            }

            return Ok(employee);
        }
        // Check
    }
}
