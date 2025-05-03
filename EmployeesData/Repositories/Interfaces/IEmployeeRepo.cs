using EmployeesData.Entities;

namespace EmployeesData.Repositories.Interfaces
{
    public interface IEmployeeRepo
    {
        Task<Employee> AddEmployee(Employee employee);
        Task<bool> DeleteEmployee(int empId);
        Task<Employee> GetEmployeeById(int id);
        Task<List<Employee>> GetEmployeesList();
        Task<Employee> UpdateEmployee(Employee employee);
    }
}