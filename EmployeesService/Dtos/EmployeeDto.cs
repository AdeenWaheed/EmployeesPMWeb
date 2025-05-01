namespace EmployeesService.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public bool isActive { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}