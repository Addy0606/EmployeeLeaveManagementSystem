using EmployeeManagerApp.Data;
using EmployeeManagerApp.Interfaces;
using EmployeeManagerApp.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagerApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }
        public async Task ApplyLeaveAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsAsync(int employeeId)
        {
            return await _context.LeaveRequests
                .Include(l => l.LeaveType)
                .Where(l => l.EmployeeId == employeeId)
                .ToListAsync();
        }
    }
}
