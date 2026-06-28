using EmployeeManagerApp.Dtos;

namespace EmployeeManagerApp.Interfaces
{
    public interface IManagerService
    {
        Task<List<PendingLeaveDto>> GetPendingRequestsAsync();

        Task ApproveLeaveAsync(int leaveRequestId, UpdateLeaveStatusDto dto);

        Task RejectLeaveAsync(int leaveRequestId, UpdateLeaveStatusDto dto);

        Task<ReportDto> GetSummaryReportAsync();
    }
}
