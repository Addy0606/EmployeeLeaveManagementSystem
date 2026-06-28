
using EmployeeManagerApp.DTOs;
using EmployeeManagerApp.Interfaces;
using EmployeeManagerApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeManagerApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {   
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service; 
        }
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var employeeId = int.Parse(
    User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var profile = await _service.GetProfileAsync(employeeId);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }
        [HttpGet("leavebalance")]
        public async Task<IActionResult> GetLeaveBalance()
        {
            var employeeId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var bal = await _service.GetLeaveBalanceAsync(employeeId);
            if (bal == null)
            {
                return NotFound();
            }
            return Ok(bal);
        }
        [HttpPost("applyleave")]
        public async Task<IActionResult> ApplyLeave(ApplyLeaveDto request)
        {
            var employeeId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            await _service.ApplyLeaveAsync(employeeId, request);
            return Ok("Leave request submitted.");
        }
        [HttpGet("leaves")]
        public async Task<IActionResult> GetLeaveHistory()
        {
            var employeeId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var history = await _service.GetLeaveHistoryAsync(employeeId);

            return Ok(history);
        }
    }
}
