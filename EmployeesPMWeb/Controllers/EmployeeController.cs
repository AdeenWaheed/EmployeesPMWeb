using EmployeesService.Dtos;
using EmployeesService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesPMWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var empList = await _employeeService.GetEmployeesList();

            return Json(new { data = empList });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    var emp = await _employeeService.AddEmployee(employeeDto);
                    return Json(new { success = true, message = "Employee added successfully" });
                }
                return Json(new { success = false, message = "Validations failed while adding employee" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error while adding employee" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = await _employeeService.UpdateEmployee(employeeDto);
                    return Json(new { success = true, message = "Employee updated successfully" });
                }
                return Json(new { success = false, message = "Validations failed while updating employee" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error while updating employee" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee([FromQuery] int empId)
        {
            try
            {
                if(empId == 0) return Json(new { success = false, message = "Employee Id should be greaster than 0" });

                 var resp = await _employeeService.DeleteEmployee(empId);

                 if (resp)
                        return Json(new { success = true, message = "Employee deleted successfully" });
                 else 
                        return Json(new { success = false, message = "Error while deleting employee" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error while deleting employee" });
            }
        }
    }
}
