using EmployeeManagerApp.Dtos;
using EmployeeManagerApp.Interfaces;

namespace EmployeeManagerApp.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _repository;
        private readonly IEmployeeRepository _erepository;

        public ManagerService(IManagerRepository repository, IEmployeeRepository erepository)
        {
            _repository = repository;
            _erepository= erepository;
        }


        public async Task ApproveLeaveAsync(int leaveRequestId, UpdateLeaveStatusDto dto)
        {
            var leaveRequest = await _repository.GetLeaveRequestByIdAsync(leaveRequestId);

            if (leaveRequest == null)
            {
                throw new Exception("Leave request not found.");
            }

            if (leaveRequest.Status != "Pending")
            {
                throw new Exception("This request has already been processed.");
            }

            leaveRequest.Status = "Approved";
            leaveRequest.ManagerComment = dto.ManagerComment;

            leaveRequest.Employee.LeaveBalance--;

            await _repository.UpdateLeaveRequestAsync(leaveRequest);
        }

        public async Task<List<PendingLeaveDto>> GetPendingRequestsAsync()
        {
            var pendingrequests = await _repository.GetPendingRequestsAsync();
            var pending = pendingrequests.Select(lr => new PendingLeaveDto
            {
                LeaveRequestId = lr.LeaveRequestId,
                EmployeeName = lr.Employee.FirstName + " " + lr.Employee.LastName,
                LeaveType = lr.LeaveType.LeaveName,
                StartDate = lr.StartDate,
                EndDate = lr.EndDate,
                Reason = lr.Reason,
                Status = lr.Status.ToString()
            }).ToList();
            return pending;
        }

        public Task<ReportDto> GetSummaryReportAsync()
        {
            return _repository.GetSummaryReportAsync(); 
        }

        public async Task RejectLeaveAsync(int leaveRequestId, UpdateLeaveStatusDto dto)
        {
          
            var leaveRequest = await _repository.GetLeaveRequestByIdAsync(leaveRequestId);

            if (leaveRequest == null)
            {
                throw new Exception("Leave request not found.");
            }

            if (leaveRequest.Status != "Pending")
            {
                throw new Exception("This request has already been processed.");
            }

            leaveRequest.Status = "Rejected";
            leaveRequest.ManagerComment = dto.ManagerComment;

            leaveRequest.Employee.LeaveBalance--;

            await _repository.UpdateLeaveRequestAsync(leaveRequest);
        
        }
    }
}
