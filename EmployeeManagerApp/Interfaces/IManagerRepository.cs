using EmployeeManagerApp.Dtos;
using EmployeeManagerApp.Models;

namespace EmployeeManagerApp.Interfaces
{
    public interface IManagerRepository
    {
        Task<List<LeaveRequest>> GetPendingRequestsAsync();

        Task<LeaveRequest?> GetLeaveRequestByIdAsync(int leaveRequestId);

        Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest);

        Task<ReportDto> GetSummaryReportAsync();
    }
}
