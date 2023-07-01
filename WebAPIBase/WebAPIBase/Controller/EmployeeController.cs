using Microsoft.AspNetCore.Mvc;
using WebAPIBase.BusinessLayers.Contracts;
using WebAPIBase.Models;

namespace WebAPIBase.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeBusinessLayer _employeeBusinessLayer;
        public EmployeeController(IEmployeeBusinessLayer employeeBusinessLayer)
        {
            _employeeBusinessLayer = employeeBusinessLayer;
        }

        /// <summary>
        /// Get list of all Emplyees
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetEmployees")]
        public ActionResult<List<Employee>> GetEmployees()
        {
            return _employeeBusinessLayer.GetEmployees();
        }

        /// <summary>
        /// Get employee by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}",Name = "GetEmployeeById")]
        public ActionResult<Employee> GetEmployeeById(int Id)
        {
            return _employeeBusinessLayer.GetEmployee(Id);
        }

        /// <summary>
        /// Add a new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddEmployee")]
        public ActionResult<Employee> AddEmployee([FromBody] Employee employee)
        {
            return _employeeBusinessLayer.AddEmployee(employee);
        }

        /// <summary>
        /// Update an employee by Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateEmployee")]
        public ActionResult<Employee> UpdateEmployee(int employeeId, Employee employee)
        {
            return _employeeBusinessLayer.UpdateEmployee(employeeId, employee);
        }

        /// <summary>
        /// Delete an employee by Id
        /// </summary>
        /// <param name="employeeId"></param>
        [HttpDelete(Name = "DeleteEmployee")]
        public void DeleteEmployee(int employeeId)
        {
            _employeeBusinessLayer.DeleteEmployee(employeeId);
        }
    }
}
