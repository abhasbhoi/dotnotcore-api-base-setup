using WebAPIBase.Models;

namespace WebAPIBase.Repository.Contract
{
    public interface IEmployeeRepository : IDisposable
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(int employeeId, Employee employee);
        void DeleteEmployee(int employeeId);
        void Save();
    }
}
