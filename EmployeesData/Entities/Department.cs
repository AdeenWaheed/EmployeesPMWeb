using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesData.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
