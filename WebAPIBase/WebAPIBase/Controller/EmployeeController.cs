using Microsoft.AspNetCore.Mvc;
using WebAPIBase.BusinessLayers.Contracts;
using WebAPIBase.Models;

namespace WebAPIBase.Controller
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeBusinessLayer _employeeBusinessLayer;
        public EmployeeController(IEmployeeBusinessLayer employeeBusinessLayer)
        {
            _employeeBusinessLayer = employeeBusinessLayer;
        }

        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return _employeeBusinessLayer.GetEmployees();
        }

        [HttpGet]
        public Employee GetEmployee(int employeeId)
        {
            return _employeeBusinessLayer.GetEmployee(employeeId);
        }

        [HttpPost]
        public Employee AddEmployee(Employee employee)
        {
            return _employeeBusinessLayer.AddEmployee(employee);
        }

        [HttpPut]
        public Employee UpdateEmployee(int employeeId, Employee employee)
        {
            return _employeeBusinessLayer.UpdateEmployee(employeeId, employee);
        }

        [HttpDelete]
        public void DeleteEmployee(int employeeId)
        {
            _employeeBusinessLayer.DeleteEmployee(employeeId);
        }
    }
}
