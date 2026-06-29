using EmployeeManagerApp.Dtos;
using EmployeeManagerApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagerApp.Controllers
{
    [Authorize(Roles = "Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _service;

        public ManagerController(IManagerService service)
        {
            _service = service;
        }
        [HttpGet("pendingrequests")]
        public async Task<IActionResult> GetPendingRequestsAsync()
        {
            var pendingRequests = await _service.GetPendingRequestsAsync();
            return Ok(pendingRequests);
        }
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApproveLeaveAsync(int id, [FromBody] UpdateLeaveStatusDto dto)
        {
            await _service.ApproveLeaveAsync(id, dto);

            return Ok("Request approved successfully.");
        }
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummaryReportAsync()
        {
            var report = await _service.GetSummaryReportAsync();
            return Ok(report);
        }
        [HttpPut("reject/{id}")]
        public async Task<IActionResult> RejectLeaveAsync(int id, [FromBody] UpdateLeaveStatusDto dto)
        {
            await _service.RejectLeaveAsync(id, dto);

            return Ok("Request rejected successfully.");
        }

    }
}
