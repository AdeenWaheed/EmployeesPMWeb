using EmployeesData.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesData.DBContext
{
    public class EmployeeDBContext: DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>()
            //    .ToTable("Employees");
            //modelBuilder.Entity<Department>()
            //    .ToTable("Department");
            //modelBuilder.Entity<EmployeeDepartment>()
            //    .ToTable("EmployeeDepartments");
        }
    }
}
