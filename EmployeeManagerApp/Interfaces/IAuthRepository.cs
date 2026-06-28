
using EmployeeManagerApp.Models;
namespace EmployeeManagerApp.Interfaces
{
    public interface IAuthRepository
    {
        Task<Employee?> GetEmployeeByEmailAsync(string email);
    }
}