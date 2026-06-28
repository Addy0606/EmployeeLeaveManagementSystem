namespace EmployeeManagerApp.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(Models.Employee employee);
    }
}