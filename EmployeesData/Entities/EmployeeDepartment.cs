using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesData.Entities
{
    [Table("EmployeeDepartments")]
    public class EmployeeDepartment
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual List<Department> Departments { get; set; }
    }
}
