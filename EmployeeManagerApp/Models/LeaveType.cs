using System.ComponentModel.DataAnnotations;

namespace EmployeeManagerApp.Models
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LeaveName { get; set; } = string.Empty;

        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    }
}