
using EmployeeManagerApp.DTOs;

namespace EmployeeManagerApp.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeProfileDto?> GetProfileAsync(int employeeId);
        Task<LeaveBalanceDto?> GetLeaveBalanceAsync(int employeeId);
        Task ApplyLeaveAsync(int employeeId,ApplyLeaveDto request);
        Task<List<LeaveHistoryDto>> GetLeaveHistoryAsync(int employeeId);
    }
}
