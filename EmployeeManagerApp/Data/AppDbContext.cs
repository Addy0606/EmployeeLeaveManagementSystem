using Microsoft.EntityFrameworkCore;

using EmployeeManagerApp.Models;

namespace EmployeeManagerApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LeaveType>().HasData(
                new LeaveType
                {
                    LeaveTypeId = 1,
                    LeaveName = "Casual Leave"
                },
                new LeaveType
                {
                    LeaveTypeId = 2,
                    LeaveName = "Sick Leave"
                },
                new LeaveType
                {
                    LeaveTypeId = 3,
                    LeaveName = "Earned Leave"
                }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Demo",
                    LastName = "Employee",
                    Email = "employee@test.com",
                    PasswordHash = "password123",
                    Department = "IT",
                    LeaveBalance = 20,
                    Role = "Employee"
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Demo",
                    LastName = "Manager",
                    Email = "manager@test.com",
                    PasswordHash = "password123",
                    Department = "HR",
                    LeaveBalance = 30,
                    Role = "Manager"
                }
            );
        }
    }
}