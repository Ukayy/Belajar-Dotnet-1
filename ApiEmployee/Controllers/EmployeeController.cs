using ApiEmployee.Data;
using ApiEmployee.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiEmployee.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeData _employeeData;
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }


        //API GET - EMPLOYEES
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        //API GET EMPLOYEE BY ID
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound("Employee Not Found!");
            }
        }


        //API ADD EMPLOYEE
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult CreateEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);

        }


        //API DELETE EMPLOYEE
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }
            else
            {
                return NotFound("Employee Not Found!");
            }
        }

        //API UPDATE EMPLOYEE
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var existEmployee = _employeeData.GetEmployee(id);
            if (existEmployee != null)
            {
                employee.Id = existEmployee.Id;
                _employeeData.EditEmployee(employee);
            }
            return Ok(employee);
        }
    }
}
