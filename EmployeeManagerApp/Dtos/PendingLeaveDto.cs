namespace EmployeeManagerApp.Dtos
{
    public class PendingLeaveDto
    {
        public int LeaveRequestId { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public string LeaveType { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
