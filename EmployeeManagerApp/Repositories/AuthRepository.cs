
using Microsoft.EntityFrameworkCore;

using EmployeeManagerApp.Data;
using EmployeeManagerApp.Interfaces;
using EmployeeManagerApp.Models;

namespace EmployeeManagerApp.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Employee?> GetEmployeeByEmailAsync(string email)
        {
            return await _context.Employees
               .FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
