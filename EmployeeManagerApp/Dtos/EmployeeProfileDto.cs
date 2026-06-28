namespace EmployeeManagerApp.DTOs
{
    public class EmployeeProfileDto
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public int LeaveBalance { get; set; }
    }
}