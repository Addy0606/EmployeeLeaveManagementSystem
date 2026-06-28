using EmployeeManagerApp.Data;
using EmployeeManagerApp.Dtos;
using EmployeeManagerApp.Interfaces;
using EmployeeManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerApp.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly AppDbContext _context;

        public ManagerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(int leaveRequestId)
        {
            return await _context.LeaveRequests
         .Include(l => l.Employee)
         .FirstOrDefaultAsync(l => l.LeaveRequestId == leaveRequestId);
        }

        public async Task<List<LeaveRequest>> GetPendingRequestsAsync()
        {
            return await _context.LeaveRequests
       .Include(l => l.Employee)
       .Include(l => l.LeaveType)
       .Where(l => l.Status == "Pending")
       .ToListAsync();
        }

        public async Task<ReportDto> GetSummaryReportAsync()
        {
            return new ReportDto
            {
                TotalRequests = await _context.LeaveRequests.CountAsync(),

                Approved = await _context.LeaveRequests
        .CountAsync(l => l.Status == "Approved"),

                Rejected = await _context.LeaveRequests
        .CountAsync(l => l.Status == "Rejected"),

                Pending = await _context.LeaveRequests
        .CountAsync(l => l.Status == "Pending")
            };
        }

        public async Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);

            await _context.SaveChangesAsync();
        }
    }
}
