
using EmployeeManagerApp.DTOs;

namespace EmployeeManagerApp.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
    }
}