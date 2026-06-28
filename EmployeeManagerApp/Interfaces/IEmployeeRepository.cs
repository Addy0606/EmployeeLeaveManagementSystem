using EmployeeManagerApp.Models;

namespace EmployeeManagerApp.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeByIdAsync(int employeeId);
        Task ApplyLeaveAsync(LeaveRequest leaveRequest);
        Task<List<LeaveRequest>> GetLeaveRequestsAsync(int employeeId);
    }
}
