using WebAPIBase.Models;

namespace WebAPIBase.BusinessLayers.Contracts
{
    public interface IEmployeeBusinessLayer
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(int employeeId, Employee employee);
        void DeleteEmployee(int employeeId);
    }
}
