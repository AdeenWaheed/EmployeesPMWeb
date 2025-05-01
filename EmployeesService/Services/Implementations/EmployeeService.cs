using EmployeesData.Entities;
using EmployeesData.Repositories.Interfaces;
using EmployeesService.Dtos;
using EmployeesService.Services.Interfaces;

namespace EmployeesService.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<List<EmployeeDto>> GetEmployeesList()
        {
            var empList = await _employeeRepo.GetEmployeesList();
            var empDtoList = empList.Select(x => new EmployeeDto()
            {
                Id = x.Id,
                Name = x.Name,
                Position = x.Position,
                Salary = x.Salary,
                isActive = x.isActive,
                DateOfJoining = x.DateOfJoining

            }).ToList();
            return empDtoList;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            var employee = await _employeeRepo.GetEmployeeById(id);
            if (employee == null)
                return null;

            var employeeDto = new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Position = employee.Position,
                Salary = employee.Salary,
                isActive = employee.isActive,
                DateOfJoining = employee.DateOfJoining
            };
            return employeeDto;
        }

        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Position = employeeDto.Position,
                Salary = employeeDto.Salary,
                isActive = employeeDto.isActive,
                DateOfJoining = employeeDto.DateOfJoining
            };
            var updatedEmployee = await _employeeRepo.UpdateEmployee(employee);
            var updatedEmployeeDto = new EmployeeDto()
            {
                Id = updatedEmployee.Id,
                Name = updatedEmployee.Name,
                Position = updatedEmployee.Position,
                Salary = updatedEmployee.Salary,
                isActive = updatedEmployee.isActive,
                DateOfJoining = updatedEmployee.DateOfJoining
            };
            return updatedEmployeeDto;
        }
    }
}

