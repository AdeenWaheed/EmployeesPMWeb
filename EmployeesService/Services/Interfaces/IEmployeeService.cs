using EmployeesService.Dtos;

namespace EmployeesService.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> AddEmployee(EmployeeDto employeeDto);
        Task<bool> DeleteEmployee(int empId);
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<List<EmployeeDto>> GetEmployeesList();
        Task<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto);
    }
}