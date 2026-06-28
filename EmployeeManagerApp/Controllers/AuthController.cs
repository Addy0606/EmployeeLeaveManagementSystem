
using EmployeeManagerApp.DTOs;
using EmployeeManagerApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagerApp.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var response = await _service.LoginAsync(request);

            if (response == null)
                return Unauthorized("Invalid email or password.");

            return Ok(response);
        }
    }
}