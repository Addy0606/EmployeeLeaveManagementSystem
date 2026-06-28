namespace EmployeeManagerApp.DTOs
{
    public class LeaveHistoryDto
    {
        public int LeaveRequestId { get; set; }

        public string LeaveType { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? ManagerComment { get; set; }
    }
}