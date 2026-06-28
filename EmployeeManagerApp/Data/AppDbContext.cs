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
    }
}