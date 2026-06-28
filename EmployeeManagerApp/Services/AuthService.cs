using EmployeeManagerApp.DTOs;
using EmployeeManagerApp.Interfaces;

namespace EmployeeManagerApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IJwtService _jwtService;
        public AuthService(
     IAuthRepository repository,
     IJwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
        {
            var employee = await _repository.GetEmployeeByEmailAsync(request.Email);

            if (employee == null)
                return null;

            
            if (employee.PasswordHash != request.Password)
                return null;

            return new LoginResponseDto
            {
                Token = _jwtService.GenerateToken(employee),
                Name = employee.FirstName + " " + employee.LastName,
                Role = employee.Role
            };
        }
    }
}