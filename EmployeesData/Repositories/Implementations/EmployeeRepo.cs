using EmployeesData.DBContext;
using EmployeesData.Entities;
using EmployeesData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesData.Repositories.Implementations
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeDBContext _employeeDBContext;
        public EmployeeRepo(EmployeeDBContext employeeDBContext)
        {
            _employeeDBContext = employeeDBContext;
        }

        public async Task<List<Employee>> GetEmployeesList()
        {
            return await _employeeDBContext.Employees.Where(x => x.isActive).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeDBContext.Employees.FirstOrDefaultAsync(x => x.Id == id && x.isActive);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            _employeeDBContext.Employees.Add(employee);
            await _employeeDBContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var existingEmployee = await _employeeDBContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id && x.isActive);

            if (existingEmployee == null)
                throw new Exception("Employee not found");

            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Position = employee.Position;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.DateOfJoining = employee.DateOfJoining;
                await _employeeDBContext.SaveChangesAsync();
            }
            return existingEmployee;
        }

        public async Task<bool> DeleteEmployee(int empId)
        {
            var existingEmp = await _employeeDBContext.Employees.FirstOrDefaultAsync(x => x.Id == empId);

            if (existingEmp != null)
            { 
                _employeeDBContext.Remove(existingEmp);
                await _employeeDBContext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
