using EmployeeManagerApp.Data;
using EmployeeManagerApp.DTOs;
using EmployeeManagerApp.Interfaces;
using EmployeeManagerApp.Models;
using EmployeeManagerApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _repository;
        private readonly AppDbContext _context;

        public EmployeeService(EmployeeRepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task ApplyLeaveAsync(int employeeId, ApplyLeaveDto request)
        {
            if(request.StartDate > request.EndDate)
            {
                throw new ArgumentException("Start date cannot be after end date.");
            }
            var leaveTypeExists = await _context.LeaveTypes.AnyAsync(lt => lt.LeaveTypeId == request.LeaveTypeId);
            if (!leaveTypeExists)
            {
                throw new ArgumentException("The specified leave type does not exist.");
            }
            var leaverequest = new LeaveRequest
            {
                EmployeeId = employeeId,
                LeaveTypeId = request.LeaveTypeId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Reason = request.Reason,
                Status = "Pending"
            };
            await _repository.ApplyLeaveAsync(leaverequest);
        }

        public async Task<LeaveBalanceDto?> GetLeaveBalanceAsync(int employeeId)
        {
            var employee = await _repository.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
            {
                return null;
            }
            return new LeaveBalanceDto
            {
                
                LeaveBalance = employee.LeaveBalance
            };
        }

        public async Task<List<LeaveHistoryDto>> GetLeaveHistoryAsync(int employeeId)
        {
            var leaves = await _repository.GetLeaveRequestsAsync(employeeId);

            return leaves.Select(l => new LeaveHistoryDto
            {
                LeaveType = l.LeaveType!.LeaveName,
                StartDate = l.StartDate,
                EndDate = l.EndDate,
                Status = l.Status
            }).ToList();

        }

        public async Task<EmployeeProfileDto?> GetProfileAsync(int employeeId)
        {
            var employee = await _repository.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
            {
                return null;
            }
            return new EmployeeProfileDto
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.FirstName + " " + employee.LastName,
                Email = employee.Email,
                Department = employee.Department,
                LeaveBalance = employee.LeaveBalance
            };
        }
    }
}
